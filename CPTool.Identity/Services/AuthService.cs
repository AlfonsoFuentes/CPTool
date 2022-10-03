



namespace CPTool.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
           IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User {user!.Email} found");
            }
            var result = await _signInManager.PasswordSignInAsync(user!.UserName, user!.PasswordHash, false, lockoutOnFailure: false);
            if (!result.Succeeded) throw new Exception($"Incorrect credentials");
            var token = await GenerateToken(user);

            var authresponse = new AuthResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                email = user.Email,


            };

            return authresponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {

            var existinuser = await _userManager.FindByNameAsync(request.UserName);
            if (existinuser != null)
            {
                throw new Exception($"User Name existing");

            }
            var usermail = await _userManager.FindByEmailAsync(request.Email);
            if (usermail != null)
            {
                throw new Exception($"Email existing");

            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,

            };
            var result = await _userManager.CreateAsync(user, request.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Reader");
                var token = await GenerateToken(user);
                return new RegistrationResponse()
                {
                    email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),

                    UserId = user.Id,
                    UserName = user.UserName,

                };
            }
            throw new Exception($"{result.Errors}");

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var rolesclaims = new List<Claim>();
            foreach (var row in roles)
            {
                rolesclaims.Add(new Claim(ClaimTypes.Role, row));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomsClaimsTypes.Uid, user.Id),

            }.Union(userClaims).Union(rolesclaims);


            var symetricsecuritykey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingcredentials = new SigningCredentials(symetricsecuritykey,
                SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingcredentials);
            return jwtSecurityToken;
        }
    }
}
