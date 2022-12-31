using CPTool.UnitsSystem;
using System.Net;

namespace EquipmentCalculation
{
    public class TablasDeVapor : PropertyPackageCalculator
    {
        const double TMELTX = 251.165;
        const double TLOWER = 190.0;
        const double TUPPER = 5000.0;
        const double PLOWER = 1.0e-20;
        const double PUPPER = 10000.0;
        const double TSMIN = 253.150;
        const double PSMIN = 125.45844e-6;
        //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        const double TCW = 647.096;//K
        const double PCW = 22.064;//bares
        const double RHOCW = 322.0;//Kg/m3
        const double RW = 0.461526; //kJ /kg /K, 
        const double Rm = 0.00831451; //kJ kmol?1 K?1,
        const double WM = 18.015257; //kg kmol?1 .
        const double TTRIPW = 273.16;//K
        const double PTRIPW = 611.657e-6;//bares
        const double Tb = 373.1243;//Normal Boiling Temperatura, K
        const double Pb = 0.101325; //Normal Boiling Pressure, bares

        double gamma = 0.0, gammaPI = 0.0, gammaPIPI = 0.0, gammaTAU = 0.0, gammaTAUTAU = 0.0, gammaPITAU = 0.0, gammaCero = 0.0, gammaRES = 0.0;
        public double volumenEspecificoMasico = 0.0;
        public double entalpiaMasica = 0.0;
        public double densidadMasica = 0.0;
        public double energiaInternaMasica = 0.0;
        public double entropiaMasica = 0.0;
        public double CpMasico = 0.0;
        public double CvMasico = 0.0;
        public double volumenEspecificoMolar = 0.0;
        public double entalpiaMolar = 0.0;
        public double energiaInternaMolar = 0.0;
        public double entropiaMolar = 0.0;
        public double CpMolar = 0.0;
        public double CvMolar = 0.0;
        public double densidadMolar = 0.0;
        double visco = 0.0;
        public double viscosidad = 0.0;
        public double viscosidadCinematica = 0.0;
        double presion = 0.0;
        double vs = 0.0;
        double av = 0.0;
        double kt = 0.0;
        public double conductividadTermica = 0.0;
        public double tensionSuperficial = 0.0;
        //double calidad = 0.0;

        public TablasDeVapor()
        {
        }

        double PenRegionPB23(double tt)
        {
            //cover the range from 623.15 K at 16.5292 MPa up to 863.15 K at 100 MPa.
            // el limite entre las regiones 2 y 3
            double xx;
            double n1 = 0.34805185628969e3;
            double n2 = -1.1671859879975;
            double n3 = 0.10192970039326e-2;
            xx = (n1 + n2 * tt + n3 * tt * tt);//MPa
            return xx;
        }

        double TenRegionPB23(double pp)
        {
            double TB23;
            //cover the range from 623.15 K at 16.5292 MPa up to 863.15 K at 100 MPa.
            // el limite entre las regiones 2 y 3
            double n3 = 0.10192970039326e-2;
            double n4 = 0.57254459862746e3;
            double n5 = 0.13918839778870e2;
            TB23 = (n4 + Math.Sqrt((pp - n5) / n3));//K
            return TB23;
        }

        double CalcularRegion1(double pp, double tt)
        {
            //
            //
            //           V E R I F I C A D A
            //
            //
            double p1, tau, pStar, tStar, suma = 0.0;
            int i = 0;
            tStar = 1386.0; // k
            pStar = 16.53; // MPa
            tau = tStar / tt;
            p1 = pp / pStar;
            double[] wn = { 0.14632971213167, -0.84548187169114, -3.7563603672040,
    3.3855169168385, -0.95791963387872, 0.15772038513228, -0.016616417199501,
    0.00081214629983568, 0.00028319080123804, -0.00060706301565874, -0.018990068218419,     -0.032529748770505, -0.021841717175414, -0.000052838357969930, -0.00047184321073267,
    -0.00030001780793026, 0.000047661393906987, -0.0000044141845330846, -0.72694996297594E-15, -0.000031679644845054, -0.0000028270797985312, -0.85205128120103e-9, -0.22425281908e-5,     -0.65171222895601e-6,    -0.14341729937924e-12,   -0.40516996860117e-6,-0.12734301741641e-8,
    -0.17424871230634e-9, -0.68762131295531e-18, 0.14478307828521e-19, 0.26335781662795e-22,    -0.11947622640071e-22, 0.18228094581404e-23, -0.93537087292458e-25 };
            double[] wI = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 8, 8, 21, 23, 29, 30, 31, 32 };
            double[] wJ = { -2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0,
                6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41 };

            // Rango de validez 273.15 K ≤ T ≤ 623.15 K ps(T) ≤ p ≤ 100 MPa 
            gamma = 0.0;
            for (i = 0; i < 34; i++)
                gamma += wn[i] * Math.Pow(7.1 - p1, wI[i]) * Math.Pow(tau - 1.222, wJ[i]);
            gammaPI = 0.0;
            for (i = 0; i < 34; i++)
                gammaPI += -wn[i] * wI[i] * Math.Pow(7.1 - p1, wI[i] - 1.0) * Math.Pow(tau - 1.222, wJ[i]);
            gammaPIPI = 0.0;
            for (i = 0; i < 34; i++)
                gammaPIPI += wn[i] * wI[i] * (wI[i] - 1.0) * Math.Pow(7.1 - p1, wI[i] - 2.0) * Math.Pow(tau - 1.222, wJ[i]);
            gammaTAU = 0.0;
            for (i = 0; i < 34; i++)
                gammaTAU += wn[i] * Math.Pow(7.1 - p1, wI[i]) * wJ[i] * Math.Pow(tau - 1.222, wJ[i] - 1.0);
            gammaTAUTAU = 0.0;
            for (i = 0; i < 34; i++)
                gammaTAUTAU += wn[i] * Math.Pow(7.1 - p1, wI[i]) * wJ[i] * (wJ[i] - 1.0) * Math.Pow(tau - 1.222, wJ[i] - 2.0);
            gammaPITAU = 0.0;
            for (i = 0; i < 34; i++)
                gammaPITAU += -wn[i] * wI[i] * Math.Pow(7.1 - p1, wI[i] - 1.0) * wJ[i] * Math.Pow(tau - 1.222, wJ[i] - 1.0);

            volumenEspecificoMasico = RW * tt / pp * p1 * gammaPI / 1000.0;// m3/kg

            entalpiaMasica = RW * tt * tau * gammaTAU;

            energiaInternaMasica = RW * tt * (tau * gammaTAU - p1 * gammaPI);

            entropiaMasica = RW * (tau * gammaTAU - gamma);

            CpMasico = -RW * tau * tau * gammaTAUTAU;

            double tse = (gammaPI - tau * gammaPITAU) * (gammaPI - tau * gammaPITAU) / gammaPIPI;

            CvMasico = CpMasico + RW * tse;

            tse = (gammaPI - tau * gammaPITAU) * (gammaPI - tau * gammaPITAU) / tau / tau / gammaTAUTAU - gammaPIPI;
            vs = Math.Sqrt(RW * tt * (gammaPI * gammaPI) / tse * 1000.0);
            av = (1.0 - tau * gammaPITAU / gammaPI) / tt;
            kt = p1 * gammaPIPI / gammaPI / pp;

            //************************************************//
            return suma;

        }


        double CalcularRegion2(double pp, double tt)
        {

            /// <summary>
            /// 
            /// 
            ///             V E R I F I C A D A
            /// 
            /// 
            /// 
            //        273.15 K ≤ T ≤ 623.15 K 0 < p ≤ ps(T)
            //        623.15 K < T ≤ 863.15 K 0 < p ≤ pB23(T)
            //        863.15 K < T ≤ 1 073.15 K 0 < p ≤ 100 MPa,
            double p1, tau, pStar, tStar, gGibbs = 0.0; ;//, suma = 0.0, correct = 0.0, gGibbs = 0.0;
            int i = 0;
            tStar = 540.0; // k
            pStar = 1.0; // MPa
            tau = tStar / tt;
            p1 = pp / pStar;

            p1 = pp;

            double[] wnio = { -9.6927686500217, 10.086655968018, -0.56087911283020e-2, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.3839511319450, -0.28408632460772, 0.021268463753307 };
            double[] wnJio = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] wni = { -0.17731742473213e-2, -0.17834862292358e-1, -0.045996013696365,-0.057581259083432,-0.050325278727930,
      -0.330326416792e-4, -0.18948987516315e-3, -0.39392777243355e-2, -0.043797295650573, -0.26674547914087e-4, 0.20481737692309e-7, 0.43870667284435e-6, -0.32277677238570e-4, -0.15033924542148e-2, -0.040668253562649,
        -0.78847309559367e-9, 0.12790717852285e-7, 0.48225372718507e-6, 0.22922076337661e-5, -0.16714766451061e-10, -0.21171472321355e-2, -23.895741934104,    -0.59059564324270e-17, -0.12621808899101e-5, -0.038946842435739, 0.11256211360459e-10, -8.2311340897998, 0.19809712802088e-7, 0.10406965210174e-18, -0.10234747095929e-12, -0.10018179379511e-8,  -0.80882908646985e-10, 0.10693031879409, -0.33662250574171, 0.89185845355421e-24,  0.30629316876232e-12, -0.42002467698208e-5, -0.59056029685639e-25, 0.37826947613457e-5,
      -0.12768608934681e-14, 0.73087610595061e-28, 0.55414715350778e-16, -0.94369707241210e-6 };
            int[] Ii = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            int[] Ji = { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            gammaCero = 0.0;
            for (i = 0; i < 9; i++)
                gammaCero += wnio[i] * Math.Pow(tau, wnJio[i]);
            gammaCero += Math.Log(p1);
            gammaRES = 0.0;
            for (i = 0; i < 43; i++)
                gammaRES += wni[i] * Math.Pow(p1, Ii[i]) * Math.Pow((tau - 0.5), Ji[i]);
            gGibbs = gammaCero + gammaRES;
            double gammaCeroPI = 1.0 / p1;
            double gammaCeroPIPI = -1.0 / p1 / p1;

            double gammaCeroTAU = 0.0;
            for (i = 0; i < 9; i++)
                gammaCeroTAU += wnio[i] * wnJio[i] * Math.Pow(tau, (wnJio[i] - 1));

            double gammaCeroTAUTAU = 0.0;
            for (i = 0; i < 9; i++)
                gammaCeroTAUTAU += wnio[i] * wnJio[i] * (wnJio[i] - 1.0) * Math.Pow(tau, (wnJio[i] - 2));

            //double gammaCeroPITAU = 0.0;

            double gammaRESPI = 0.0;
            for (i = 0; i < 43; i++)
                gammaRESPI += wni[i] * Ii[i] * Math.Pow(p1, Ii[i] - 1.0) * Math.Pow((tau - 0.5), Ji[i]);

            double gammaRESPIPI = 0.0;
            for (i = 0; i < 43; i++)
                gammaRESPIPI += wni[i] * Ii[i] * (Ii[i] - 1.0) * Math.Pow(p1, (Ii[i] - 2.0)) * Math.Pow((tau - 0.5), Ji[i]);

            double gammaRESTAU = 0.0;
            for (i = 0; i < 43; i++)
                gammaRESTAU += wni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * Math.Pow((tau - 0.5), (Ji[i] - 1.0));

            double gammaRESTAUTAU = 0.0;
            for (i = 0; i < 43; i++)
                gammaRESTAUTAU += wni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * (Ji[i] - 1.0) * Math.Pow((tau - 0.5), (Ji[i] - 2.0));

            double gammaRESPITAU = 0.0;
            for (i = 0; i < 43; i++)
                gammaRESPITAU += wni[i] * Ii[i] * Math.Pow(p1, (Ii[i] - 1.0)) * Ji[i] * Math.Pow((tau - 0.5), (Ji[i] - 1.0));

            volumenEspecificoMasico = RW * tt / pp * p1 * (gammaCeroPI + gammaRESPI) / 1000.0;

            entalpiaMasica = RW * tt * tau * (gammaCeroTAU + gammaRESTAU);

            energiaInternaMasica = entalpiaMasica - RW * tt * p1 * (gammaCeroPI + gammaRESPI);

            entropiaMasica = RW * tau * (gammaCeroTAU + gammaRESTAU) - RW * (gammaCero + gammaRES);

            CpMasico = -RW * tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU);

            double num = (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) / (1.0 - p1 * p1 * gammaRESPIPI);
            CvMasico = CpMasico - RW * (num);

            num = 1.0 + 2.0 * p1 * gammaRESPI + p1 * p1 * gammaRESPI * gammaRESPI;
            double denom = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU));
            denom += 1.0 - p1 * p1 * gammaRESPIPI;
            vs = Math.Sqrt(RW * tt * num / denom * 1000.0);
            av = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (1.0 + p1 * gammaRESPI) / tt;
            kt = (1.0 - p1 * p1 * gammaRESPIPI) / (1.0 + p1 * gammaRESPI) / pp;
            return 0.0;
        }

        int DeterminarRegion(double pp, double tt)
        {
            double TB23 = 0.0;// pb3 = 0.0, tb3 = 0.0, tsat = 0.0, TB23 = 0.0;
            //

            // Limites de la region 1
            //
            double pSat27315 = PresionDeSaturacion(273.15);
            if ((pp >= 16.529 && pp <= 100.0) && (tt >= 273.15 && tt <= 623.15))
            {
                if (pp >= 15.629)
                    return 1;
            }
            var tsat = TemperaturaDeSaturacion(pp);
            if (pp >= pSat27315 && pp < 15.629 && tt >= 273.15 && tt <= tsat)
                return 1;
            //
            //    limites de la region 3
            //
            if (pp > 15.629 && pp <= 100.0)
            {
                TB23 = TenRegionPB23(pp);// el limite entre las regiones 2 y 3
                if (tt > 623.15 && tt < TB23)
                    return 3;
            }
            //
            //    limites de la region 2
            //
            if (pp > 0.0 && pp < 100.0)
            {
                TB23 = TenRegionPB23(pp);// el limite entre las regiones 2 y 3
                tsat = TemperaturaDeSaturacion(pp);
                if ((tt >= TB23 || tt >= tsat) && tt <= 1073.15)
                    return 2;
            }
            //
            //    limites de la region 5
            //
            if ((pp > 0.0 && pp < 50.0) && (tt > 1073.15 && tt <= 2273.15))
                return 5;
            return 0;
        }
        double G2meta(double pp, double tt)
        {
            //
            //
            //
            //              V E R I F I C A D A
            //
            //
            double p1, tau, pStar, tStar;//, suma = 0.0;
            //double gGibbs = 0.0;
            int i = 0;
            tStar = 540.0; // k
            pStar = 1.0; // MPa
            tau = tStar / tt;
            p1 = pp / pStar;
            double[] wnio = { -9.6937268393049, 10.087275970006, -0.56087911283020e-2, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.3839511319450, -0.28408632460772, 0.021268463753307 };
            double[] wnJio = { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            double[] wni = { -0.73362260186506e-2, -0.088223831943146, -0.072334555213245, -0.40813178534455e-2, 0.20097803380207e-2,-0.053045921898642, -0.76190409086970e-2, -0.63498037657313e-2, -0.086043093028588, 0.75321581522770e-2, -0.79238375446139e-2,
    -0.22888160778447e-3, -0.26456501482810e-2 };
            double[] Ii = { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 5 };
            double[] Ji = { 0, 2, 5, 11, 1, 7, 16, 4, 16, 7, 10, 9, 10 };

            gammaCero = 0.0;
            for (i = 0; i < 9; i++)
                gammaCero += wnio[i] * Math.Pow(tau, wnJio[i]);
            gammaCero += Math.Log(p1);

            double gammaCeroPI = 1.0 / p1;
            double gammaCeroPIPI = -1.0 / p1 / p1;

            double gammaCeroTAU = 0.0;
            for (i = 0; i < 9; i++)
                gammaCeroTAU += wnio[i] * wnJio[i] * Math.Pow(tau, (wnJio[i] - 1));

            double gammaCeroTAUTAU = 0.0;
            for (i = 0; i < 9; i++)
                gammaCeroTAUTAU += wnio[i] * wnJio[i] * (wnJio[i] - 1.0) * Math.Pow(tau, (wnJio[i] - 2.0));

            //double gammaCeroPITAU = 0.0;

            gammaRES = 0.0;
            for (i = 0; i < 13; i++)
                gammaRES += wni[i] * Math.Pow(p1, Ii[i]) * Math.Pow((tau - 0.5), Ji[i]);

            double gammaRESPI = 0.0;
            for (i = 0; i < 13; i++)
                gammaRESPI += wni[i] * Ii[i] * Math.Pow(p1, Ii[i] - 1.0) * Math.Pow((tau - 0.5), Ji[i]);

            double gammaRESPIPI = 0.0;
            for (i = 0; i < 13; i++)
                gammaRESPIPI += wni[i] * Ii[i] * (Ii[i] - 1.0) * Math.Pow(p1, (Ii[i] - 2.0)) * Math.Pow((tau - 0.5), Ji[i]);

            double gammaRESTAU = 0.0;
            for (i = 0; i < 13; i++)
                gammaRESTAU += wni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * Math.Pow((tau - 0.5), (Ji[i] - 1.0));

            double gammaRESTAUTAU = 0.0;
            for (i = 0; i < 13; i++)
                gammaRESTAUTAU += wni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * (Ji[i] - 1.0) * Math.Pow((tau - 0.5), (Ji[i] - 2.0));

            double gammaRESPITAU = 0.0;
            for (i = 0; i < 13; i++)
                gammaRESPITAU += wni[i] * Ii[i] * Math.Pow(p1, (Ii[i] - 1.0)) * Ji[i] * Math.Pow((tau - 0.5), (Ji[i] - 1.0));
            var gGibbs = gammaCero + gammaRES;

            volumenEspecificoMasico = RW * tt / pp * p1 * (gammaCeroPI + gammaRESPI) / 1000.0;

            entalpiaMasica = RW * tt * tau * (gammaCeroTAU + gammaRESTAU);

            energiaInternaMasica = entalpiaMasica - RW * tt * p1 * (gammaCeroPI + gammaRESPI);

            entropiaMasica = RW * tau * (gammaCeroTAU + gammaRESTAU) - RW * (gammaCero + gammaRES);

            CpMasico = -RW * tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU);

            double num = (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) / (1.0 - p1 * p1 * gammaRESPIPI);
            CvMasico = CpMasico - RW * (num);

            num = 1.0 + 2.0 * p1 * gammaRESPI + p1 * p1 * gammaRESPI * gammaRESPI;
            double denom = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU));
            denom += 1.0 - p1 * p1 * gammaRESPIPI;
            vs = Math.Sqrt(RW * tt * num / denom * 1000.0);
            av = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (1.0 + p1 * gammaRESPI) / tt;
            kt = (1.0 - p1 * p1 * gammaRESPIPI) / (1.0 + p1 * gammaRESPI) / pp;
            return 0.0;
        }

        double CalcularRegion3(double rho, double tt)
        {
            //
            // 
            // 
            //            V E R I F I C A D A
            // 
            // 
            //        273.15 K ≤ T ≤ 623.15 K 0 < p ≤ ps(T)
            //        623.15 K < T ≤ 863.15 K 0 < p ≤ pB23(T)
            //        863.15 K < T ≤ 1 073.15 K 0 < p ≤ 100 MPa,
            double delta = 0.0, rhoc = 322.0, tau = 0.0, Tc = 647.096;// rhoc kg/m3, Tc K
            delta = rho / rhoc;
            tau = Tc / tt;
            int i = 0;
            double n1 = 1.0658070028513, suma = 0.0;
            double Phi = 0.0, PhiDelta = 0.0, PhiDeltaDelta = 0.0;
            double PhiDeltaTau = 0.0, PhiTau = 0.0, PhiTauTau = 0.0;
            double[] wn = { -15.732845290239, 20.944396974307, -7.6867707878716, 2.6185947787954, -2.8080781148620, 1.2053369696517, -0.84566812812502e-2, -1.2654315477714, -1.1524407806681, 0.88521043984318, -0.64207765181607, 0.38493460186671, -0.85214708824206, 4.8972281541877, -3.0502617256965, 0.039420536879154, 0.12558408424308, -0.27999329698710, 1.3899799569460, -2.0189915023570, -0.82147637173963e-2, -0.47596035734923, 0.043984074473500, -0.44476435428739, 0.90572070719733, 0.70522450087967, 0.10770512626332, -0.32913623258954, -0.50871062041158, -0.022175400873096, 0.094260751665092, 0.16436278447961, -0.013503372241348, -0.014834345352472, 0.57922953628084e-3, 0.32308904703711e-2, 0.80964802996215e-4, -0.16557679795037e-3, -0.44923899061815e-4 };
            int[] Ii = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 8, 9, 9, 10, 10, 11 };
            int[] Ji = { 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17, 0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26, 0, 1, 26 };
            for (i = 0; i < 39; i++)
                Phi += wn[i] * Math.Pow(delta, Ii[i]) * Math.Pow(tau, Ji[i]);
            Phi += n1 * Math.Log(delta);
            for (i = 0; i < 39; i++)
                PhiDelta += wn[i] * Ii[i] * Math.Pow(delta, Ii[i] - 1.0) * Math.Pow(tau, Ji[i]);
            PhiDelta += n1 / delta;
            for (i = 0; i < 39; i++)
                PhiDeltaDelta += wn[i] * Ii[i] * (Ii[i] - 1.0) * Math.Pow(delta, Ii[i] - 2.0) * Math.Pow(tau, Ji[i]);
            PhiDeltaDelta += -n1 / delta / delta;
            for (i = 0; i < 39; i++)
                PhiDeltaTau += wn[i] * Ii[i] * Math.Pow(delta, Ii[i] - 1.0) * Ji[i] * Math.Pow(tau, Ji[i] - 1.0);
            for (i = 0; i < 39; i++)
                PhiTau += wn[i] * Math.Pow(delta, Ii[i]) * Ji[i] * Math.Pow(tau, Ji[i] - 1.0);
            for (i = 0; i < 39; i++)
                PhiTauTau += wn[i] * Math.Pow(delta, Ii[i]) * Ji[i] * (Ji[i] - 1.0) * Math.Pow(tau, Ji[i] - 2.0);

            presion = rho * RW * tt * delta * PhiDelta / 1000.0;

            entalpiaMasica = RW * tt * (tau * PhiTau + delta * PhiDelta);

            energiaInternaMasica = RW * tt * tau * PhiTau;

            entropiaMasica = RW * (tau * PhiTau - Phi);

            CpMasico = RW * (-tau * tau * PhiTauTau + (delta * PhiDelta - delta * tau * PhiDeltaTau) * (delta * PhiDelta - delta * tau * PhiDeltaTau) / (2.0 * delta * PhiDelta + delta * delta * PhiDeltaDelta));

            CvMasico = -RW * tau * tau * PhiTauTau;

            suma = 2.0 * delta * PhiDelta + delta * delta * PhiDeltaDelta - (delta * PhiDelta - delta * tau * PhiDeltaTau) * (delta * PhiDelta - delta * tau * PhiDeltaTau) / tau / tau / PhiTauTau;
            vs = Math.Sqrt(RW * tt * suma * 1000.0);

            av = (PhiDelta - tau * PhiDeltaTau) / (2.0 * PhiDelta + delta * PhiDeltaDelta) / tt;
            kt = 1000.0 / (2.0 * delta * PhiDelta + delta * delta * PhiDeltaDelta) / rho / RW / tt;

            double relativePressureCoefficient = (1.0 - tau * PhiDeltaTau / PhiDelta) / tt;

            double isxothermalStressCofficient = rho * (2.0 + delta * PhiDeltaDelta / PhiDelta);

            return 0.0;
        }

        public double PresionDeSaturacion(double ts)
        {

            //
            //
            //
            //              V E R I F I C A D A
            //
            /*
            1 0.116 705 214 527 67 × 104        6 0.149 151 086 135 30 × 102
              2 − 0.724 213 167 032 06 × 106      7 − 0.482 326 573 615 91 × 104
              3 − 0.170 738 469 400 92 × 102      8 0.405 113 405 420 57 × 106
              4 0.120 208 247 024 70 × 105        9 − 0.238 555 575 678 49
              5 − 0.323 255 503 223 33 × 107      10 0.650 175 348 447 98 × 103
          */
            //
            double tStar = 1.0, A = 0.0, B = 0.0, C = 0.0, pSat = 0.0, vr = 0.0, ssr = 0.0;

            double[] vn = { 0.0,0.11670521452767e4, -0.72421316703206e6, -0.17073846940092e2, 0.12020824702470e5, -0.32325550322333e7,
        0.14915108613530e2, -0.48232657361591e4, 0.40511340542057e6, -0.23855557567849, 0.65017534844798e3 };
            vr = ts + vn[9] / (ts - vn[10]);
            A = vr * vr + vn[1] * vr + vn[2];
            B = vn[3] * vr * vr + vn[4] * vr + vn[5];
            C = vn[6] * vr * vr + vn[7] * vr + vn[8];
            ssr = Math.Sqrt(B * B - 4.0 * A * C);
            pSat = Math.Pow(2 * C / (-B + ssr), 4);
            return pSat;
        }

        public double TemperaturaDeSaturacion(double ps)
        {
            //  
            //
            //
            //              V E R I F I C A D A
            //
            //
            double pStar = 1.0, D = 0.0, E = 0.0, F = 0.0, G = 0.0, tSat = 0.0, inter = 0.0;
            double vr = Math.Pow(ps / pStar, 0.25);
            double[] vn = { 0.0,0.11670521452767e4, -0.72421316703206e6, -0.17073846940092e2, 0.12020824702470e5, -0.32325550322333e7,
        0.14915108613530e2, -0.48232657361591e4, 0.40511340542057e6, -0.23855557567849, 0.65017534844798e3 };

            E = vr * vr + vn[3] * vr + vn[6];
            F = vn[1] * vr * vr + vn[4] * vr + vn[7];
            G = vn[2] * vr * vr + vn[5] * vr + vn[8];
            D = 2.0 * G / (-F - Math.Sqrt(Math.Abs(F * F - 4.0 * E * G)));
            inter = (vn[10] + D) * (vn[10] + D) - 4.0 * (vn[9] + vn[10] * D);
            tSat = (vn[10] + D - Math.Sqrt(inter)) / 2.0;
            return tSat;
        }

        double CalcularRegion5(double pp, double tt)
        {
            //        273.15 K ≤ T ≤ 623.15 K 0 < p ≤ ps(T)
            //        623.15 K < T ≤ 863.15 K 0 < p ≤ pB23(T)
            //        863.15 K < T ≤ 1 073.15 K 0 < p ≤ 100 MPa,
            //
            //
            //         V e r i f i c a d a
            //
            //
            //
            double tau = 0.0, tStar = 0.0, p1 = 0.0, pStar = 0.0, Tc = 647.096;// rhoc kg/m3, Tc K
            p1 = pp;
            tau = 1000.0 / tt;
            int i = 0;

            double[] no = { -13.179983674201, 6.8540841634434, -0.024805148933466, 0.36901534980333, -3.1161318213925, -0.32961626538917 };
            int[] Io = { 0, 1, -3, -2, -1, 2 };
            double[] ni = { 0.15736404855259e-2, 0.90153761673944e-3, -0.50270077677648e-2, 0.22440037409485e-5, -0.41163275453471e-5, 0.37919454822955e-7 };
            int[] Ii = { 1, 1, 1, 2, 2, 3 };
            int[] Ji = { 1, 2, 3, 3, 9, 7 };
            double gammaCero = 0.0;
            for (i = 0; i < 6; i++)
                gammaCero += no[i] * Math.Pow(tau, Io[i]);
            gammaCero += Math.Log(p1);
            double gammaCeroPI = 1.0 / p1;
            double gammaCeroPIPI = -1.0 / p1 / p1;
            double gammaCeroTAU = 0.0;
            for (i = 0; i < 6; i++)
                gammaCeroTAU += no[i] * Io[i] * Math.Pow(tau, (Io[i] - 1.0));
            double gammaCeroTAUTAU = 0.0;
            for (i = 0; i < 6; i++)
                gammaCeroTAUTAU += no[i] * Io[i] * (Io[i] - 1.0) * Math.Pow(tau, (Io[i] - 2.0));
            double gammaCeroPiTAU = 0.0;
            double gammaRES = 0.0;
            for (i = 0; i < 6; i++)
                gammaRES += ni[i] * Math.Pow(p1, Ii[i]) * Math.Pow(tau, Ji[i]);
            double gammaRESPI = 0.0;
            for (i = 0; i < 6; i++)
                gammaRESPI += ni[i] * Ii[i] * Math.Pow(p1, (Ii[i] - 1.0)) * Math.Pow(tau, Ji[i]);
            double gammaRESPIPI = 0.0;
            for (i = 0; i < 6; i++)
                gammaRESPIPI += ni[i] * Ii[i] * (Ii[i] - 1.0) * Math.Pow(p1, (Ii[i] - 2.0)) * Math.Pow(tau, Ji[i]);
            double gammaRESTAU = 0.0;
            for (i = 0; i < 6; i++)
                gammaRESTAU += ni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * Math.Pow(tau, (Ji[i] - 1.0));
            double gammaRESTAUTAU = 0.0;
            for (i = 0; i < 6; i++)
                gammaRESTAUTAU += ni[i] * Math.Pow(p1, Ii[i]) * Ji[i] * (Ji[i] - 1.0) * Math.Pow(tau, (Ji[i] - 2.0));
            double gammaRESPITAU = 0.0;
            double gGibbs = gammaCero + gammaRES;
            for (i = 0; i < 6; i++)
                gammaRESPITAU += ni[i] * Ii[i] * Math.Pow(p1, (Ii[i] - 1.0)) * Ji[i] * Math.Pow(tau, (Ji[i] - 1.0));

            volumenEspecificoMasico = RW * tt / pp * p1 * (gammaCeroPI + gammaRESPI) / 1000.0;

            entalpiaMasica = RW * tt * tau * (gammaCeroTAU + gammaRESTAU);

            energiaInternaMasica = entalpiaMasica - RW * tt * p1 * (gammaCeroPI + gammaRESPI);

            entropiaMasica = RW * tau * (gammaCeroTAU + gammaRESTAU) - RW * (gammaCero + gammaRES);

            CpMasico = -RW * tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU);

            double num = (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - p1 * tau * gammaRESPITAU) / (1.0 - p1 * p1 * gammaRESPIPI);
            CvMasico = CpMasico - RW * (num);

            num = 1.0 + 2.0 * p1 * gammaRESPI + p1 * p1 * gammaRESPI * gammaRESPI;
            double denom = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) * (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (tau * tau * (gammaCeroTAUTAU + gammaRESTAUTAU));
            denom += 1.0 - p1 * p1 * gammaRESPIPI;
            vs = Math.Sqrt(RW * tt * num / denom * 1000.0);
            av = (1.0 + p1 * gammaRESPI - tau * p1 * gammaRESPITAU) / (1.0 + p1 * gammaRESPI) / tt;
            kt = (1.0 - p1 * p1 * gammaRESPIPI) / (1.0 + p1 * gammaRESPI) / pp;
            return 0.0;
        }

        double ViscosidadDinamicaDeVolumenEspecifico(double pp, double tt, double vuu)
        {
            double mu0 = 0.0, mu1 = 0.0, delta = 0.0, rho = 0.0, teta = 0.0, nuStar = 0.0;
            double phiCero = 0.0, phiUno = 0.0, nu = 0.0, rhoStar = 322.0, tStar = 647.096;
            rho = 1.0 / vuu;
            nuStar = 1.0e-6; //Pa seg
            teta = tt / tStar;
            int i = 0;
            delta = rho / rhoStar;
            double sum0 = 0.0, sum1 = 0.0;
            double[] nio = { 0.167752e-1, 0.220462e-1, 0.6366564e-2, -0.241605e-2 };
            double[] ni = { 0.520094, 0.0850895, -1.08374, -0.289555, 0.222531, 0.999115, 1.88797,
    1.26613, 0.120573, -0.281378, -0.906851, -0.772479, -0.489837, -0.257040, 0.161913, 0.257399,-0.0325372, 0.0698452, 0.872102e-2, -0.435673e-2, -0.593264e-3 };
            int[] Ii = { 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4, 4, 5, 6, 6 };
            int[] Ji = { 0, 1, 2, 3, 0, 1, 2, 3, 5, 0, 1, 2, 3, 4, 0, 1, 0, 3, 4, 3, 5 };
            for (i = 0; i <= 3; i++)
                sum0 += nio[i] * Math.Pow(1.0 / teta, i);
            phiCero = Math.Sqrt(teta) / sum0;
            for (i = 0; i < 21; i++)
                sum1 += ni[i] * Math.Pow(delta - 1.0, Ii[i]) * Math.Pow((1.0 - teta) / teta, Ji[i]);
            phiUno = Math.Exp(delta * sum1);
            nu = nuStar * phiCero * phiUno;
            visco = 1000.0 * nu;
            viscosidad = nu;
            return nu;
        }


        double ViscosidadDinamicaDeDensidad(double pp, double tt, double rho)
        {
            double mu0 = 0.0, mu1 = 0.0, delta = 0.0, teta = 0.0, nuStar = 0.0;
            double phiCero = 0.0, phiUno = 0.0, nu = 0.0, rhoStar = 322.0, tStar = 647.096;
            nuStar = 1.0e-6; //Pa seg
            teta = tt / tStar;
            int i = 0;
            delta = rho / rhoStar;
            double sum0 = 0.0, sum1 = 0.0;
            double[] nio = { 0.167752e-1, 0.220462e-1, 0.6366564e-2, -0.241605e-2 };
            double[] ni = { 0.520094, 0.0850895, -1.08374, -0.289555, 0.222531, 0.999115, 1.88797,
    1.26613, 0.120573, -0.281378, -0.906851, -0.772479, -0.489837, -0.257040, 0.161913, 0.257399,-0.0325372, 0.0698452, 0.872102e-2, -0.435673e-2, -0.593264e-3 };
            int[] Ii = { 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4, 4, 5, 6, 6 };
            int[] Ji = { 0, 1, 2, 3, 0, 1, 2, 3, 5, 0, 1, 2, 3, 4, 0, 1, 0, 3, 4, 3, 5 };
            for (i = 0; i <= 3; i++)
                sum0 += nio[i] * Math.Pow(1.0 / teta, i);
            phiCero = Math.Sqrt(teta) / sum0;
            for (i = 0; i < 21; i++)
                sum1 += ni[i] * Math.Pow(delta - 1.0, Ii[i]) * Math.Pow((1.0 - teta) / teta, Ji[i]);
            phiUno = Math.Exp(delta * sum1);
            nu = nuStar * phiCero * phiUno;
            visco = 1000.0 * nu;  //Pascal seg
            viscosidad = nu;
            return nu;
        }


        double CalcularDensidad(double pp, double tt)
        {
            return 0.0;
        }


        double thermalConductivity(double rho, double tt)
        {
            double Acero = 0.0, Auno = 0.0, Ados = 0.0, delta = 0.0, sum = 0.0, deltaTeta = 0.0;
            double kt = 0.0, rhoStar = 317.7, tStar = 647.26, teta = 0.0, ktStar = 0.0, A, B;
            ktStar = 1.0; //W /m /K
            teta = tt / tStar;
            int i = 0;
            delta = rho / rhoStar;
            double sum0 = 0.0, sum1 = 0.0;
            double[] nio = { 0.0102811, 0.0299621, 0.0156146, -0.422464e-2 }; //Tabla 3.4 pag Pagina 156
            double[] ni = { -0.397070, 0.400302, 1.06, -0.171587, 2.39219 };//Tabla 3.5 pag Pagina 156
            for (i = 0; i < 4; i++)
                sum += nio[i] * Math.Pow(teta, i);
            Acero = Math.Sqrt(teta) * sum;
            Auno = ni[0] + ni[1] * delta + ni[2] * Math.Exp(ni[3] * (ni[4] + delta) * (ni[4] + delta));
            double[] no = { 0.0701309, 0.0118520, 0.642857, 0.169937e-2, -1.02, -4.11717, -6.17937, 0.0822994, 10.0932, 0.308976e-2 };
            deltaTeta = Math.Abs(teta - 1.0) + no[9];
            A = 2.0 + no[7] / Math.Pow(deltaTeta, 0.6);
            if (teta >= 1.0)
                B = 1.0 / deltaTeta;
            else
                B = no[8] / Math.Pow(deltaTeta, 0.6);
            Ados = (no[0] / Math.Pow(teta, 10) + no[1]) * Math.Pow(delta, 1.8) * Math.Exp(no[2] * (1.0 - Math.Pow(delta, 2.8))) + no[3] * A * Math.Pow(delta, B) * Math.Exp(B / (1.0 + B) * (1.0 - Math.Pow(delta, 1.0 + B)))
                + no[4] * Math.Exp(no[5] * Math.Pow(teta, 1.5) + no[6] * Math.Pow(delta, -5));
            kt = Acero + Auno + Ados;//W/K/m
            conductividadTermica = kt;
            return kt;
        }

        double SurfaceTension(double tt)
        {
            double psi = 0.0, psiStar = 1.0e-3, tStar = 647.096, teta = 0.0;
            teta = tt / tStar;
            psi = 235.8 * Math.Pow((1.0 - teta), 1.256) * (1.0 - 0.625 * (1.0 - teta));
            psi *= psiStar;
            tensionSuperficial = psi;
            return psi;
        }

        int BoundariesForPHBack(double pp, double hh)
        {
            CalcularRegion1(pp, 273.15);
            double hCero = entalpiaMasica; // entalpia a pp y 273.25
            CalcularRegion2(pp, 1073.15);
            double TB23;
            double pSat62315K, pSat27315K;
            pSat27315K = PresionDeSaturacion(273.15);
            pSat62315K = PresionDeSaturacion(623.15);//Boundary between Regions 3 and 4.
            CalcularRegion2(pp, 1073.15);
            double hMas = entalpiaMasica; // entalpia a pp y 1073.15
            if ((pp > 100 || pp < 0.000611212677) && (hh < hCero && hh > hMas))//limites de presiones
                return -1; // La ecuacion no se aplica a esta region

            /// 
            /// 
            /// 
            /// Para la region Uno
            /// 
            /// 
            /// 

            // Boundary between Regions 1 and 4
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                double T1ph = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, T1ph);
                if (hh > hCero && hh <= entalpiaMasica)
                    return 1;
            }
            //Boundary between Regions 3 and 4.

            CalcularRegion1(pSat62315K, 623.15);
            double h1Prima = entalpiaMasica;
            CalcularRegion2(pSat62315K, 623.15);
            double h2Prima = entalpiaMasica;

            if (hh >= h1Prima && hh <= h2Prima)
            {
                if (pp >= CalcularPSat3DeEntalpia(hh))
                    return 3;
            }
            //Boundary between Regions 2 and 4
            if (pp >= pSat27315K && pp <= pSat62315K)
            {

                CalcularRegion2(pp, TemperaturaDeSaturacion(pp));
                if (hh >= entalpiaMasica)
                    return 2;
            }
            //Boundary between Regions 

            if (pp >= pSat62315K && pp <= 100.0)
            {
                double h12 = 0.0, h23 = 0.0;
                //Boundary between Regions 1 y 3
                CalcularRegion1(pp, 623.15);
                h12 = entalpiaMasica;
                TB23 = TenRegionPB23(pp);
                CalcularRegion2(pp, TB23);
                h23 = entalpiaMasica;
                if (hh <= h12)
                    return 1;
                //Boundary between Regions 2 y 3
                else if (hh >= h23 && hh <= hMas)
                    return 2;
                double p3Sat = CalcularPSat3DeEntalpia(hh);
                if (pp >= p3Sat && pp <= 100 && hh > h12 && hh < h23)
                    return 3;
            }
            return 4;//Por defecto
        }

        int BoundariesForPSBack(double pp, double ss)
        {
            CalcularRegion1(pp, 273.15);
            double sCero = entropiaMasica; // entalpia a pp y 273.25
            CalcularRegion2(pp, 1073.15);
            double TB23;
            double pSat62315K, pSat27315K;
            pSat27315K = PresionDeSaturacion(273.15);
            pSat62315K = PresionDeSaturacion(623.15);//Boundary between Regions 3 and 4.
            CalcularRegion2(pp, 1073.15);
            double sMas = entropiaMasica; // entalpia a pp y 1073.15
            if ((pp > 100 || pp < 0.000611212677) && (ss < sCero && ss > sMas))//limites de presiones
                return -1; // La ecuacion no se aplica a esta region

            /// 
            /// 
            /// 
            /// Para la region Uno
            /// 
            /// 
            /// 

            // Boundary between Regions 1 and 4
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                double T1ph = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, T1ph);
                if (ss > sCero && ss <= entropiaMasica)
                    return 1;
            }
            //Boundary between Regions 3 and 4.

            CalcularRegion1(pSat62315K, 623.15);
            double s1Prima = entropiaMasica;
            CalcularRegion2(pSat62315K, 623.15);
            double s2Prima = entropiaMasica;

            if (ss >= s1Prima && ss <= s2Prima)
            {
                if (pp >= CalcularPSat3DeEntropia(ss))
                    return 3;
            }
            //Boundary between Regions 2 and 4
            if (pp >= pSat27315K && pp <= pSat62315K)
            {

                CalcularRegion2(pp, TemperaturaDeSaturacion(pp));
                if (ss >= entropiaMasica)
                    return 2;
            }
            //Boundary between Regions 

            if (pp >= pSat62315K && pp <= 100.0)
            {
                double s12 = 0.0, s23 = 0.0;
                //Boundary between Regions 1 y 3
                CalcularRegion1(pp, 623.15);
                s12 = entropiaMasica;
                TB23 = TenRegionPB23(pp);
                CalcularRegion2(pp, TB23);
                s23 = entropiaMasica;
                if (ss <= s12)
                    return 1;
                //Boundary between Regions 2 y 3
                else if (ss >= s23 && ss <= sMas)
                    return 2;
                double p3Sat = CalcularPSat3DeEntropia(ss);
                if (pp >= p3Sat && pp <= 100 && ss > s12 && ss < s23)
                    return 3;
            }
            return 4;// por defecto
        }

        double CalcularT1ph(double pp, double hh)
        {
            double T1ph = 0.0, nu = hh / 2500.0;
            double[] no = { -0.23872489924521e3, 0.40421188637945e3, 0.11349746881718e3, -0.58457616048039e1, -0.15285482413140e-3, -0.10866707695377e-5, -0.13391744872602e2, 0.43211039183559e2, -0.54010067170506e2, 0.30535892203916e2, -0.65964749423638e1, 0.93965400878363e-2, 0.11573647505340e-6, -0.25858641282073e-4, -0.40644363084799e-8, 0.66456186191635e-7, 0.80670734103027e-10, -0.93477771213947e-12, 0.58265442020601e-14, -0.15020185953503e-16 };
            int[] I = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 5, 6 };
            int[] J = { 0, 1, 2, 6, 22, 32, 0, 1, 2, 3, 4, 10, 32, 10, 32, 10, 32, 32, 32, 32 };
            int i;
            for (i = 0; i < 20; i++)
                T1ph += no[i] * Math.Pow(pp, I[i]) * Math.Pow(nu + 1.0, J[i]);
            return T1ph;
        }

        double CalcularPSat3DeEntalpia(double hh)
        {
            double pSat = 0.0, hStar = 2600.0, pStar = 22.0, nu = 0.0, sum = 0.0;
            double[] nn = { 0.600073641753024, -9.36203654849857, 24.6590798594147, -107.014222858224, -0.915821315805768e14, -0.862332011700662e4, -0.235837344740032e2, 0.252304969384128e18, -0.389718771997719e19, -0.333775713645296e23, 0.356499469636328e11, -0.148547544720641e27, 0.330611514838798e19, 0.813641294467829e38 };
            int[] I = { 0, 1, 1, 1, 1, 5, 7, 8, 14, 20, 22, 24, 28, 36 };
            int[] J = { 0, 1, 3, 4, 36, 3, 0, 24, 16, 16, 3, 18, 8, 24 };
            nu = hh / hStar;
            for (int i = 0; i < 14; i++)
                sum += nn[i] * Math.Pow(nu - 1.02, I[i]) * Math.Pow(nu - 0.608, J[i]);
            pSat = sum * pStar;
            return pSat;
        }

        double CalcularV3ph(double pp, double hh)
        {
            double V3 = 0;
            double h3ab = BoundariesRegion3a3b(pp);
            if (hh < h3ab)
                V3 = CalcularV3Aph(pp, hh);
            else
                V3 = CalcularV3Bph(pp, hh);
            return V3;
        }


        double CalcularT3ph(double pp, double hh)
        {
            double T3 = 0.0;
            double h3ab = BoundariesRegion3a3b(pp);
            if (hh < h3ab)
                T3 = CalcularT3Aph(pp, hh);
            else
                T3 = CalcularT3Bph(pp, hh);
            return T3;

        }

        double BoundariesRegion3a3b(double pp)
        {
            double[] no = { 0.201464004206875e4, 0.374696550136983e1, -0.219921901054157e-1, 0.875131686009950e-4 };
            double h3AB = no[0] + no[1] * pp + no[2] * pp * pp + no[3] * pp * pp * pp;
            return h3AB;
        }


        double CalcularV3Aph(double pp, double hh)
        {
            double V3a = 0.0;
            double[] no = { 0.529944062966028e-2, -0.17009969023446118e-1, 0.111323814312927e2, -0.217898123145125e4, -0.50606182798087e-3, 0.556495239685324, -0.943672726094016e1, -0.297856807561527, 0.939353943717186e2, 0.192944939465981e-1, 0.421740664704763, -0.368914126282330e7, -0.737566847600639e-2, -0.35475324242466, -0.199768169338727e1, 0.115456297059049e1, 0.568366875815960e4, 0.808169540124668e-2, 0.172416341519307, 0.104270175292927e1, -0.297691372792847, 0.560394465163593, 0.275234661176914, -0.148347894866012, -0.651142513478515e-1, -0.292468715386302e1, 0.664876096952665e-1, 0.352335014263844e1, -0.146340792313332e-1, -0.224503486668184e1, 0.110533464706142e1, -0.408757344495612e-1 };
            int[] I = { -12, -12, -12, -12, -10, -10, -10, -8, -8, -6, -6, -6, -4, -4, -3, -2, -2, -1, -1, -1, -1, 0, 0, 1, 1, 1, 2, 2, 3, 4, 5, 8 };
            int[] J = { 6, 8, 12, 18, 4, 7, 10, 5, 12, 3, 4, 22, 2, 3, 7, 3, 16, 0, 1, 2, 3, 0, 1, 0, 1, 2, 0, 2, 0, 2, 2, 2 };
            int i;
            double vStar = 0.0028, pStar = 100.0, hStar = 2100.0;
            double w = 0.0, p1, nu;
            p1 = pp / pStar;
            nu = hh / hStar;
            for (i = 0; i < 32; i++)
                w += no[i] * Math.Pow(p1 + 0.128, I[i]) * Math.Pow(nu - 0.727, J[i]);
            V3a = w * vStar;
            return V3a;
        }

        double CalcularV3Bph(double pp, double hh)
        {
            int i;
            double vStar = 0.0088, pStar = 100.0, hStar = 2800.0;
            double w = 0.0, p1, nu;
            p1 = pp / pStar;
            nu = hh / hStar;
            double V3b = 0.0;
            double[] no = { -0.225196934336318e-8, 0.140674363313486e-7, 0.233784085280560e-5, -0.331833715229001e-4, 0.107956778514318e-2, -0.271382067378863, 0.107202262490333e1, -0.853821329075382, -0.21521419434052e-4, 0.769656088222730e-3, -0.431136580433864e-2, 0.453342167309331, -0.507749535873652, -0.100475154528389e3, -0.219201924648793, -0.321087965668917e1, 0.607567815637771e3, 0.557686450685932e-3, 0.187499040029550, 0.905368030448107e-2, 0.285417173048685, 0.329924030996098e-1, 0.239897419685483, 0.482754995951394e1, -0.118035753702231e2, 0.169490044091791, -0.179967222507787e-1, 0.371810116332674e-1, -0.536288335065096e-1, 0.160697101092520e1 };
            int[] I = { -12, -12, -8, -8, -8, -8, -8, -8, -6, -6, -6, -6, -6, -6, -4, -4, -4, -3, -3, -2, -2, -1, -1, -1, -1, 0, 1, 1, 2, 2 };
            int[] J = { 0, 1, 0, 1, 3, 6, 7, 8, 0, 1, 2, 5, 6, 10, 3, 6, 10, 0, 2, 1, 2, 0, 1, 4, 5, 0, 0, 1, 2, 6 };
            for (i = 0; i < 30; i++)
                w += no[i] * Math.Pow(p1 + 0.0661, I[i]) * Math.Pow(nu - 0.720, J[i]);
            V3b = w * vStar;
            return V3b;
        }


        double CalcularT3Aph(double pp, double hh)
        {
            int i;
            double tStar = 760.0, pStar = 100.0, hStar = 2300.0;
            double teta = 0.0, p1, nu;
            p1 = pp / pStar;
            nu = hh / hStar;
            double T3a = 0.0;
            double[] no = { -0.133645667811215e-6, 0.455912656802978e-5, -0.146294640700979e-4, 0.639341312970080e-2, 0.372783927268847e3, -0.718654377460447e4, 0.573494752103400e6, -0.267569329111439e7, -0.334066283302614e-4, -0.245479214069597e-1, 0.478087847764996e2, 0.764664131818904e-5, 0.128350627676972e-2, 0.171219081377331e-1, -0.851007304583213e1, -0.136513461629781e-1, -0.384460997596657e-5, 0.337423807911655e-2, -0.551624873066791, 0.729202277107470, -0.992522757376041e-2, -0.119308831407288, 0.793929190615421, 0.454270731799386, 0.209998591259910, -0.642109823904738e-2, -0.235155868604540e-1, 0.252233108341612e-2, -0.764885133368119e-2, 0.136176427574291e-1, -0.133027883575669e-1 };
            double[] I = { -12, -12, -12, -12, -12, -12, -12, -12, -10, -10, -10, -8, -8, -8, -8, -5, -3, -2, -2, -2, -1, -1, 0, 0, 1, 3, 3, 4, 4, 10, 12 };
            double[] J = { 0, 1, 2, 6, 14, 16, 20, 22, 1, 5, 12, 0, 2, 4, 10, 2, 0, 1, 3, 4, 0, 2, 0, 1, 1, 0, 1, 0, 3, 4, 5 };
            for (i = 0; i < 31; i++)
                teta += no[i] * Math.Pow(p1 + 0.240, I[i]) * Math.Pow(nu - 0.615, J[i]);
            T3a = teta * tStar;
            return T3a;
        }


        double CalcularT3Bph(double pp, double hh)
        {
            int i;
            double tStar = 860.0, pStar = 100.0, hStar = 2800.0;
            double teta = 0.0, p1, nu;
            p1 = pp / pStar;
            nu = hh / hStar;
            double T3b = 0.0;
            double[] no = { 0.323254573644920e-4, -0.127575556587181e-3, -0.475851877356068e-3, 0.156183014181602e-2, 0.105724860113781, -0.858514221132534e2, 0.724140095480911e3, 0.296475810273257e-2, -0.592721983365988e-2, -0.126305422818666e-1, -0.115716196364853, 0.849000969739595e2, -0.108602260086615e-1, 0.154304475328851e-1, 0.750455441524466e-1, 0.252520973612982e-1, -0.602507901232996e-1, -0.307622221350501e1, -0.574011959864879e-1, 0.503471360939849e1, -0.925081888584834, 0.391733882917546e1, -0.773146007130190e2, 0.949308762098587e4, -0.141043719679409e7, 0.849166230819026e7, 0.861095729446704, 0.323346442811720, 0.873281936020439, -0.436653048526683, 0.286596714529479, -0.131778331276228, 0.676682064330275e-2 };
            double[] I = { -12, -12, -10, -10, -10, -10, -10, -8, -8, -8, -8, -8, -6, -6, -6, -4, -4, -3, -2, -2, -1, -1, -1, -1, -1, -1, 0, 0, 1, 3, 5, 6, 8 };
            double[] J = { 0, 1, 0, 1, 5, 10, 12, 0, 1, 2, 4, 10, 0, 1, 2, 0, 1, 5, 0, 4, 2, 4, 6, 10, 14, 16, 0, 2, 1, 1, 1, 1, 1 };
            for (i = 0; i < 33; i++)
                teta += no[i] * Math.Pow(p1 + 0.298, I[i]) * Math.Pow(nu - 0.720, J[i]);
            T3b = teta * tStar;
            return T3b;
        }





        double BoundaryRegionp2B2C(double hh)
        {
            double p2b2c = 0.0, nu = hh;
            double n1 = 0.90584278514723e3;
            double n2 = -0.67955786399241;
            double n3 = 0.12809002730136e-3;
            p2b2c = n1 + n2 * nu + n3 * nu * nu;
            return p2b2c;
        }

        double BoundaryRegionh2B2C(double pp)
        {
            double h2b2c = 0.0, p1 = pp;
            double n3 = 0.12809002730136e-3;
            double n4 = 0.26526571908428e4;
            double n5 = 0.45257578905948e1;
            h2b2c = n4 + Math.Sqrt((p1 - n5) / n3);
            return h2b2c;
        }

        double CalcularT2Aph(double pp, double hh)
        {
            double[] no = { 0.10898952318288e4, 0.84951654495535e3, -0.10781748091826e3, 0.33153654801263e2, -0.74232016790248e1, 0.11765048724356e2, 0.18445749355790e1, -0.41792700549624e1, 0.62478196935812e1, -0.17344563108114e2,-0.20058176862096e3, 0.27196065473796e3, -0.45511318285818e3, 0.30919688604755e4, 0.25226640357872e6, -0.61707422868339e-2,
    -0.31078046629583, 0.11670873077107e2, 0.12812798404046e9, -0.98554909623276e9,
    0.28224546973002e10, -0.35948971410703e10, 0.17227349913197e10, -0.13551334240775e5,
    0.12848734664650e8, 0.13865724283226e1, 0.23598832556514e6, -0.13105236545054e8,
    0.73999835474766e4, -0.55196697030060e6, 0.37154085996233e7, 0.19127729239660e5,
    -0.41535164835634e6, -0.62459855192507e2 };
            double[] I = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7 };
            double[] J = { 0, 1, 2, 3, 7, 20, 0, 1, 2, 3, 7, 9, 11, 18, 44, 0, 2, 7, 36, 38, 40, 42, 44, 24, 44, 12, 32, 44, 32, 36, 42, 34, 44, 28 };
            int i;
            double teta = 0.0, nu = hh / 2000, p1 = pp;
            for (i = 0; i < 34; i++)
                teta += no[i] * Math.Pow(p1, I[i]) * Math.Pow(nu - 2.1, J[i]);
            return teta;
        }

        double CalcularT2Bph(double pp, double hh)
        {
            double[] no = { 0.14895041079516e4, 0.74307798314034e3, -0.97708318797837e2, 0.24742464705674e1, -0.63281320016026, 0.11385952129658e1, -0.47811863648625, 0.85208123431544e-2, 0.93747147377932, 0.33593118604916e1, 0.33809355601454e1, 0.16844539671904, 0.73875745236695, -0.47128737436186, 0.15020273139707, -0.21764114219750e-2, -0.21810755324761e-1, -0.10829784403677, -0.46333324635812e-1, 0.71280351959551e-4, 0.11032831789999e-3, 0.18955248387902e-3, 0.30891541160537e-2, 0.13555504554949e-2, 0.28640237477456e-6, -0.10779857357512e-4, -0.76462712454814e-4, 0.14052392818316e-4, -0.31083814331434e-4, -0.10302738212103e-5, 0.28217281635040e-6, 0.12704902271945e-5, 0.73803353468292e-7, -0.11030139238909e-7, -0.81456365207833e-13, -0.25180545682962e-10, -0.17565233969407e-17, 0.86934156344163e-14 };
            double[] I = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 7, 7, 9, 9 };
            double[] J = { 0,1,2,12,18,24,28,40,0,2,6,12,18,24,28,40,2,8,18,40,1,2,
        12,24,2,12,18,24,28,40,18,24,40,28,2,28,1,40 };
            int i;
            double teta = 0.0, nu = hh / 2000.0, p1 = pp;
            for (i = 0; i < 38; i++)
                teta += no[i] * Math.Pow(p1 - 2.0, I[i]) * Math.Pow(nu - 2.6, J[i]);
            return teta;
        }

        double CalcularT2Cph(double pp, double hh)
        {
            double T2aph = 0.0;
            double[] no = { -0.32368398555242e13, 0.73263350902181e13, 0.35825089945447e12, -0.58340131851590e12, -0.10783068217470e11, 0.20825544563171e11, 0.61074783564516e6,
        0.85977722535580e6, -0.25745723604170e5, 0.31081088422714e5, 0.12082315865936e4, 0.48219755109255e3, 0.37966001272486e1, -0.10842984880077e2, -0.45364172676660e-1, 0.14559115658698e-12, 0.11261597407230e-11, -0.17804982240686e-10, 0.12324579690832e-6, -0.11606921130984e-5, 0.27846367088554e-4, -0.59270038474176e-3, 0.12918582991878e-2 };
            double[] I = { -7, -7, -6, -6, -5, -5, -2, -2, -1, -1, 0, 0, 1, 1, 2, 6, 6, 6, 6, 6, 6, 6, 6 };
            double[] J = { 0, 4, 0, 2, 0, 2, 0, 1, 0, 2, 0, 1, 4, 8, 4, 0, 1, 4, 10, 12, 16, 20, 22 };
            int i;
            double teta = 0.0, nu = hh / 2000, p1 = pp;
            for (i = 0; i < 23; i++)
                teta += no[i] * Math.Pow(p1 + 25.0, I[i]) * Math.Pow(nu - 1.8, J[i]);
            return teta;
        }

        double CalcularT2ph(double pp, double hh)
        {
            double T2ph;
            if (pp > 0.000611 && pp < 4.0)
            {
                T2ph = CalcularT2Aph(pp, hh);
                return T2ph;
            }
            double H2bc = BoundaryRegionh2B2C(pp);
            if (hh > H2bc)
            {
                T2ph = CalcularT2Bph(pp, hh);
                return T2ph;
            }
            else
            {
                T2ph = CalcularT2Cph(pp, hh);
                return T2ph;
            }
        }


        double CalcularT1ps(double pp, double ss)
        {
            double[] no = { 0.17478268058307e3, 0.34806930892873e2, 0.65292584978455e1, 0.33039981775489,
    -0.19281382923196e-6, -0.24909197244573e-22, -0.26107636489332, 0.22592965981586, -0.64256463395226e-1, 0.78876289270526e-2, 0.35672110607366e-9, 0.17332496994895e-23, 0.56608900654837e-3, -0.32635483139717e-3, 0.44778286690632e-4, -0.51322156908507e-9, -0.42522657042207e-25, 0.26400441360689e-12, 0.78124600459723e-28, -0.30732199903668e-30 };
            int[] I = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4 };
            int[] J = { 0, 1, 2, 3, 11, 31, 0, 1, 2, 3, 12, 31, 0, 1, 2, 9, 31, 10, 32, 32 };
            double teta = 0.0;
            int i;
            for (i = 0; i < 20; i++)
                teta += no[i] * Math.Pow(pp, I[i]) * Math.Pow(ss + 2.0, J[i]);
            return teta;
        }

        double CalcularT2ps(double pp, double ss)
        {
            double T2ps;
            double S2bc = 5.85;
            if (pp > 0.000611 && pp < 4.0)
            {
                T2ps = CalcularT2Aps(pp, ss);
                return T2ps;
            }

            if (ss >= S2bc)
            {
                T2ps = CalcularT2Bps(pp, ss);
                return T2ps;
            }
            else
            {
                T2ps = CalcularT2Cps(pp, ss);
                return T2ps;
            }
        }

        double CalcularT2Aps(double pp, double ss)
        {
            double su = ss / 2.0;
            double teta = 0.0;
            int i;
            double[] no = { -0.39235983861984e6, 0.51526573827270e6, 0.40482443161048e5, -0.32193790923902e3, 0.96961424218694e2,-0.22867846371773e2, -0.44942914124357e6, -0.50118336020166e4, 0.35684463560015, 0.44235335848190e5, -0.13673388811708e5, 0.42163260207864e6, 0.22516925837475e5,0.47442144865646e3, -0.14931130797647e3, -0.19781126320452e6, -0.23554399470760e5, -0.19070616302076e5, 0.55375669883164e5, 0.38293691437363e4, -0.60391860580567e3,  0.19363102620331e4, 0.42660643698610e4, -0.59780638872718e4, -0.70401463926862e3, 0.33836784107553e3, 0.20862786635187e2, 0.33834172656196e-1,
    -0.43124428414893e-4, 0.16653791356412e3, -0.13986292055898e3, -0.78849547999872,
    0.72132411753872e-1, -0.59754839398283e-2, -0.12141358953904e-4, 0.23227096733871e-6,
    -0.10538463566194e2, 0.20718925496502e1, -0.72193155260427e-1, 0.20749887081120e-6,
    -0.18340657911379e-1, 0.29036272348696e-6, 0.21037527893619, 0.25681239729999e-3,
    -0.12799002933781e-1, -0.82198102652018e-5 };
            double[] I = { -1.5, -1.5, -1.5, -1.5, -1.5, -1.5, -1.25, -1.25, -1.25, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -0.75, -0.75, -0.5, -0.5, -0.5, -0.5, -0.25, -0.25, -0.25, -0.25, 0.25, 0.25, 0.25, 0.25, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.75, 0.75, 0.75, 0.75, 1.0, 1.0, 1.25, 1.25, 1.5, 1.5 };
            int[] J = { -24, -23, -19, -13, -11, -10, -19, -15, -6, -26, -21, -17, -16, -9, -8, -15, -14, -26, -13, -9, -7, -27, -25, -11, -6, 1, 4, 8, 11, 0, 1, 5, 6, 10, 14, 16, 0, 4, 9, 17, 7, 18, 3, 15, 5, 18 };
            for (i = 0; i < 46; i++)
                teta += no[i] * Math.Pow(pp, I[i]) * Math.Pow(su - 2.0, J[i]);
            return teta;
        }

        double CalcularT2Bps(double pp, double ss)
        {
            int i;
            double su = ss / 0.7853;
            double teta = 0.0;
            double[] no = { 0.31687665083497e6, 0.20864175881858e2, -0.39859399803599e6, -0.21816058518877e2, 0.22369785194242e6, -0.27841703445817e4, 0.99207436071480e1, -0.75197512299157e5, 0.29708605951158e4, -0.34406878548526e1, 0.38815564249115, 0.17511295085750e5,
    -0.14237112854449e4, 0.10943803364167e1, 0.89971619308495, -0.33759740098958e4,
    0.47162885818355e3, -0.19188241993679e1, 0.41078580492196, -0.33465378172097,
    0.13870034777505e4, -0.40663326195838e3, 0.41727347159610e2, 0.21932549434532e1,
     -0.10320050009077e1, 0.35882943516703, 0.52511453726066e-2, 0.12838916450705e2,
    -0.28642437219381e1,0.56912683664855, -0.99962954584931e-1, -0.32632037778459e-2,
    0.23320922576723e-3, -0.15334809857450, 0.29072288239902e-1, 0.37534702741167e-3,
    0.17296691702411e-2, -0.38556050844504e-3, -0.35017712292608e-4, -0.14566393631492e-4,
    0.56420857267269e-5, 0.41286150074605e-7, -0.20684671118824e-7, 0.16409393674725e-8 };
            int[] I = { -6, -6, -5, -5, -4, -4, -4, -3, -3, -3, -3, -2, -2, -2, -2, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5 };
            int[] J = { 0, 11, 0, 11, 0, 1, 11, 0, 1, 11, 12, 0, 1, 6, 10, 0, 1, 5, 8, 9, 0, 1, 2, 4, 5, 6, 9, 0, 1, 2, 3, 7, 8, 0, 1, 5, 0, 1, 3, 0, 1, 0, 1, 2 };
            for (i = 0; i < 44; i++)
                teta += no[i] * Math.Pow(pp, I[i]) * Math.Pow(10.0 - su, J[i]);
            return teta;

        }
        double CalcularT2Cps(double pp, double ss)
        {
            int i;
            double[] no = { 0.90968501005365e3, 0.24045667088420e4, -0.59162326387130e3, 0.54145404128074e3,-0.27098308411192e3, 0.97976525097926e3, -0.46966772959435e3, 0.14399274604723e2, -0.19104204230429e2, 0.53299167111971e1,-0.21252975375934e2,
        -0.31147334413760, 0.60334840894623, -0.42764839702509e-1, 0.58185597255259e-2,
    -0.14597008284753e-1, 0.56631175631027e-2, -0.76155864584577e-4, 0.22440342919332e-3,
    -0.12561095013413e-4, 0.63323132660934e-6, -0.20541989675375e-5, 0.36405370390082e-7, -0.29759897789215e-8, 0.10136618529763e-7, 0.59925719692351e-11, -0.20677870105164e-10, -0.20874278181886e-10, 0.10162166825089e-9, -0.16429828281347e-9 };
            int[] I = { -2, -2, -1, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7, 7, 7 };
            int[] J = { 0, 1, 0, 0, 1, 2, 3, 0, 1, 3, 4, 0, 1, 2, 0, 1, 5, 0, 1, 4, 0, 1, 2, 0, 1, 0, 1, 3, 4, 5 };
            double su = ss / 2.9251;
            double teta = 0.0;
            for (i = 0; i < 30; i++)
                teta += no[i] * Math.Pow(pp, I[i]) * Math.Pow(2.0 - su, J[i]);
            return teta;
        }


        double CalcularV3ps(double pp, double ss)
        {
            double V3vps = 0.0;
            double sc = 4.41202148223476;
            if (ss <= sc)
            {
                V3vps = CalcularV3Aps(pp, ss);
                return V3vps;
            }
            else
            {
                V3vps = CalcularV3Bps(pp, ss);
                return V3vps;
            }
        }

        double CalcularV3Aps(double pp, double ss)
        {
            int i;
            double[] no = { 0.795544074093975e2, -0.238261242984590e4, 0.176813100617787e5, -0.110524727080379e-2, -0.153213833655326e2, 0.297544599376982e3, -0.350315206871242e8, 0.277513761062119, -0.523964271036888, -0.148011182995403e6, 0.160014899374266e7, 0.170802322663427e13, 0.246866996006494e-3, 0.165326084797980e1, -0.118008384666987,
    0.253798642355900e1, 0.965127704669424, -0.282172420532826e2, 0.203224612353823,
    0.110648186063513e1, 0.526127948451280, 0.277000018736321, 0.108153340501132e1,
    -0.744127885357893e-1, 0.164094443541384e-1, -0.680468275301065e-1, 0.257988576101640e-1,
    -0.145749861944416e-3 };
            int[] I = { -12, -12, -12, -10, -10, -10, -10, -8, -8, -8, -8, -6, -5, -4, -3, -3, -2, -2, -1, -1, 0, 0, 0, 1, 2, 4, 5, 6 };
            int[] J = { 10, 12, 14, 4, 8, 10, 20, 5, 6, 14, 16, 28, 1, 5, 2, 4, 3, 8, 1, 2, 0, 1, 3, 0, 0, 2, 2, 0 };
            double v3A = 0.0;
            double omega = 0.0;
            double pStar = 100.0, sStar = 4.4, vStar = 0.0028;
            double p1 = pp / pStar;
            double su = ss / sStar;
            for (i = 0; i < 30; i++)
                omega += no[i] * Math.Pow(p1 + 0.187, I[i]) * Math.Pow(su - 0.755, J[i]);
            v3A = omega * vStar;
            return v3A;
        }

        /*
        1 −12 0 0.591 599 780 322 238 × 10−4            17 −4 2 − 0.121 613 320 606 788 × 102
        2 −12 1 − 0.185 465 997 137 856 × 10−2          18 −4 3 0.167 637 540 957 944 × 101
        3 −12 2 0.104 190 510 480 013 × 10−1            19 −3 1 − 0.744 135 838 773 463 × 101
        4 −12 3 0.598 647 302 038 590 × 10−2            20 −2 0 0.378 168 091 437 659 × 10−1
        5 −12 5 − 0.771 391 189 901 699                 21 −2 1 0.401 432 203 027 688 × 101
        6 −12 6 0.172 549 765 557 036 × 101             22 −2 2 0.160 279 837 479 185 × 102
        7 −10 0 − 0.467 076 079 846 526 × 10−3          23 −2 3 0.317 848 779 347 728 × 101
        8 −10 1 0.134 533 823 384 439 × 10−1            24 −2 4 − 0.358 362 310 304 853 × 101
        9 −10 2 − 0.808 094 336 805 495 × 10−1          25 −2 12 − 0.115 995 260 446 827 × 107
        10 −10 4 0.508 139 374 365 767                  26  0 0 0.199 256 573 577 909
        11 −8 0 0.128 584 643 361 683 × 10−2            27  0 1 − 0.122 270 624 794 624
        12 −5 1 − 0.163 899 353 915 435 × 101           28  0 2 − 0.191 449 143 716 586 × 102
        13 −5 2 0.586 938 199 318 063 × 101             29  1 0 − 0.150 448 002 905 284 × 10−1
        14 −5 3 − 0.292 466 667 918 613 × 101           30  1 2 0.146 407 900 162 154 × 102
        15 −4 0 − 0.614 076 301 499 537 × 10−2          31  2 2 − 0.327 477 787 188 230 × 101
        16 −4 1 0.576 199 014 049 172 × 101
        */


        double CalcularV3Bps(double pp, double ss)
        {
            int i;
            double[] no = { 0.591599780322238e-4, -0.185465997137856e-2, 0.104190510480013e-1, 0.598647302038590e-2, -0.771391189901699, 0.172549765557036e1, -0.467076079846526e-3, 0.134533823384439e-1, -0.808094336805495e-1, 0.508139374365767, 0.128584643361683e-2,
    -0.163899353915435e1, 0.586938199318063e1, -0.292466667918613e1, -0.614076301499537e-2,
    0.576199014049172e1, -0.121613320606788e2, 0.167637540957944e1, -0.744135838773463e1,
    0.378168091437659e-1, 0.401432203027688e1, 0.160279837479185e2, 0.317848779347728e1,
    -0.358362310304853e1, -0.115995260446827e7, 0.199256573577909, -0.122270624794624,
    -0.191449143716586e2, -0.150448002905284e-1, 0.146407900162154e2, -0.327477787188230e1 };
            int[] I = { -12, -12, -12, -12, -12, -12, -10, -10, -10, -10, -8, -5, -5, -5, -4, -4, -4, -4, -3, -2, -2, -2, -2, -2, -2, 0, 0, 0, 1, 1, 2 };
            int[] J = { 0, 1, 2, 3, 5, 6, 0, 1, 2, 4, 0, 1, 2, 3, 0, 1, 2, 3, 1, 0, 1, 2, 3, 4, 12, 0, 1, 2, 0, 2, 2 };
            double v3B = 0.0;
            double omega = 0.0;
            double pStar = 100.0, sStar = 5.3, vStar = 0.0088;
            double p1 = pp / pStar;
            double su = ss / sStar;
            for (i = 0; i < 30; i++)
                omega += no[i] * Math.Pow(p1 + 0.298, I[i]) * Math.Pow(su - 0.816, J[i]);
            v3B = omega * vStar;
            return v3B;
        }

        double CalcularT3ps(double pp, double ss)
        {
            double T3vps = 0.0;
            double sc = 4.41202148223476;
            if (ss <= sc)
            {
                T3vps = CalcularT3Aps(pp, ss);
                return T3vps;
            }
            else
            {
                T3vps = CalcularT3Bps(pp, ss);
                return T3vps;
            }
        }


        double CalcularT3Aps(double pp, double ss)
        {
            double T3A = 0.0;
            double teta = 0.0;
            double pStar = 100.0, sStar = 4.4, tStar = 760.0;
            double p1 = pp / pStar;
            double su = ss / sStar;
            double[] no = { 0.150042008263875e10, -0.159397258480424e12, 0.502181140217975e-3, -0.672057767855466e2, 0.145058545404456e4, -0.823889534888890e4, -0.154852214233853,
    0.112305046746695e2, -0.297000213482822e2,  0.438565132635495e11, 0.137837838635464e-2,
    -0.297478527157462e1, 0.971777947349413e13, -0.571527767052398e-4, 0.288307949778420e5,
    -0.744428289262703e14, 0.128017324848921e2, -0.368275545889071e3, 0.664768904779177e16,
    0.449359251958880e-1, -0.422897836099655e1, -0.240614376434179, -0.474341365254924e1,
    0.724093999126110, 0.923874349695897, 0.399043655281015e1, 0.384066651868009e-1,
    -0.359344365571848e-2, -0.735196448821653, 0.188367048396131, 0.141064266818704e-3,
    -0.257418501496337e-2, 0.123220024851555e-2 };
            int[] I = { -12, -12, -10, -10, -10, -10, -8, -8, -8, -8, -6, -6, -6, -5, -5, -5, -4, -4, -4, -2, -2, -1, -1, 0, 0, 0, 1, 2, 2, 3, 8, 8, 10 };
            int[] J = { 28, 32, 4, 10, 12, 14, 5, 7, 8, 28, 2, 6, 32, 0, 14, 32, 6, 10, 36, 1, 4, 1, 6, 0, 1, 4, 0, 0, 3, 2, 0, 1, 2 };
            int i;
            for (i = 0; i < 33; i++)
                teta += no[i] * Math.Pow(p1 + 0.240, I[i]) * Math.Pow(su - 0.703, J[i]);
            T3A = teta * tStar;
            return T3A;

        }


        double CalcularT3Bps(double pp, double ss)
        {
            double T3B = 0.0;
            double teta = 0.0;
            double pStar = 100.0, sStar = 5.3, tStar = 860.0;
            double p1 = pp / pStar;
            double su = ss / sStar;
            int i;
            double[] no = { 0.527111701601660, -0.401317830052742e2, 0.153020073134484e3, -0.224799398218827e4, -0.193993484669048, -0.140467557893768e1, 0.426799878114024e2, 0.752810643416743, 0.226657238616417e2, -0.622873556909932e3, -0.660823667935396, 0.841267087271658,
    -0.253717501764397e2, 0.485708963532948e3, 0.880531517490555e3, 0.265015592794626e7,
    -0.359287150025783, -0.656991567673753e3, 0.241768149185367e1, 0.856873461222588,
    0.655143675313458, -0.213535213206406, 0.562974957606348e-2, -0.316955725450471e15,
    -0.699997000152457e-3, 0.119845803210767e-1, 0.193848122022095e-4, -0.215095749182309e-4 };
            int[] I = { -12, -12, -12, -12, -8, -8, -8, -6, -6, -6, -5, -5, -5, -5, -5, -4, -3, -3, -2, 0, 2, 3, 4, 5, 6, 8, 12, 14 };
            int[] J = { 1, 3, 4, 7, 0, 1, 3, 0, 2, 4, 0, 1, 2, 4, 6, 12, 1, 6, 2, 0, 1, 1, 0, 24, 0, 3, 1, 2 };
            for (i = 0; i < 28; i++)
                teta += no[i] * Math.Pow(p1 + 0.760, I[i]) * Math.Pow(su - 0.818, J[i]);
            T3B = teta * tStar;
            return T3B;
        }

        double CalcularFlashPresionEntalpia(double pp, double hh)
        {
            pp /= 10.0;
            double Tph = 0.0, Vph = 0.0;
            int iRegion = BoundariesForPHBack(pp, hh); ;
            switch (iRegion)
            {
                case 1:
                    Tph = CalcularT1ph(pp, hh);
                    CalcularRegion1(pp, Tph);
                    break;
                case 2:
                    Tph = CalcularT2ph(pp, hh);
                    CalcularRegion2(pp, Tph);
                    break;
                case 3:
                    Tph = CalcularT3ph(pp, hh);
                    Vph = CalcularV3ph(pp, hh);
                    densidadMasica = 1.0 / Vph;
                    volumenEspecificoMasico = Vph;
                    CalcularRegion3(densidadMasica, Tph);
                    break;
                case 4:
                    Tph = CalcularRegion4ph(pp, hh);
                    break;
            }
            volumenEspecificoMolar = volumenEspecificoMasico * WM;
            entalpiaMolar = entalpiaMasica * WM;
            energiaInternaMolar = energiaInternaMasica * WM;
            entropiaMolar = entropiaMasica * WM;
            CpMolar = CpMasico * WM;
            CvMolar = CvMasico * WM;
            densidadMasica = 1.0 / volumenEspecificoMasico;
            densidadMolar = densidadMasica * WM;
            viscosidad = ViscosidadDinamicaDeVolumenEspecifico(pp, Tph, volumenEspecificoMasico);
            conductividadTermica = thermalConductivity(densidadMasica, Tph);
            tensionSuperficial = SurfaceTension(Tph);
            viscosidadCinematica = viscosidad / densidadMasica;
            return Tph;
        }

        double CalcularRegion4ph(double pp, double hh)
        {
            double pSat27315K = PresionDeSaturacion(273.15);
            double pSat62315K = PresionDeSaturacion(623.15);
            double volLiqSat = 0.0, volVapSat = 0.0, enerIntLiqSat = 0.0, enerIntVapSat = 0.0, entaLiqSat = 0.0, entaVapSat = 0.0, CpLiqSat = 0.0, CpVapSat = 0.0;
            double entroLiqSat = 0.0, entroVapSat = 0.0, viscoLiqSat = 0.0, viscoVapSat = 0.0, conduLiqSat = 0.0, conduVapSat = 0.0, CvLiqSat = 0.0, CvVapSat = 0.0;
            double calidad = 0.0, tSat = 0.0, densidad = 0.0, rhoLiqSat = 0.0, rhoVapSat = 0.0, volCritico = 1.0 / RHOCW, volEspec = 0.0;
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                tSat = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, tSat);
                entaLiqSat = entalpiaMasica;
                enerIntLiqSat = energiaInternaMasica;
                volLiqSat = volumenEspecificoMasico;
                CpLiqSat = CpMasico;
                entroLiqSat = entropiaMasica;
                viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                densidad = 1.0 / volLiqSat;
                conduLiqSat = thermalConductivity(densidad, tSat);

                CvLiqSat = CvMasico;
                CalcularRegion2(pp, tSat);
                entaVapSat = entalpiaMasica;
                enerIntVapSat = energiaInternaMasica;
                volVapSat = volumenEspecificoMasico;
                densidad = 1.0 / volVapSat;
                CpVapSat = CpMasico;
                entroVapSat = entropiaMasica;
                viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                conduVapSat = thermalConductivity(densidad, tSat);
                CvVapSat = CvMasico;
            }
            else if (pp > pSat62315K && pp < 22.064)
            {
                tSat = TemperaturaDeSaturacion(pp);
                volEspec = CalcularV3pt(pp, tSat);
                if (volEspec < volCritico)
                {
                    volLiqSat = volEspec;
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoLiqSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat);
                    CvLiqSat = CvMasico;
                    volVapSat = CalcularV3pt(pp, tSat + 0.00001);
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat + 0.00001, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat + 0.00001);
                    CvVapSat = CvMasico;
                }
                else if (volEspec > volCritico)
                {
                    volVapSat = volEspec;
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvMasico;
                    volLiqSat = CalcularV3pt(pp, tSat - 0.00001);
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat - 0.00001, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat + 0.00001);
                    CvLiqSat = CvMasico;
                }
                else if (volEspec == volCritico)
                {
                    volVapSat = volLiqSat = volEspec;
                    rhoVapSat = rhoLiqSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entaLiqSat = entalpiaMasica;
                    enerIntVapSat = enerIntLiqSat = energiaInternaMasica;
                    CpVapSat = CpLiqSat = CpMasico;
                    entroVapSat = entroLiqSat = entropiaMasica;
                    viscoVapSat = viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = conduLiqSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvLiqSat = CvMasico;
                }

            }
            calidad = (hh - entaLiqSat) / (entaVapSat - entaLiqSat);
            energiaInternaMasica = calidad * enerIntVapSat + (1.0 - calidad) * enerIntLiqSat;
            volumenEspecificoMasico = calidad * volVapSat + (1.0 - calidad) * volLiqSat;
            densidad = 1.0 / volumenEspecificoMasico;
            CpMasico = calidad * CpVapSat + (1.0 - calidad) * CpLiqSat;
            entropiaMasica = calidad * entroVapSat + (1.0 - calidad) * entroLiqSat;
            CvMasico = calidad * CvVapSat + (1.0 - calidad) * CvLiqSat;
            viscosidad = (volVapSat * viscoVapSat + volLiqSat * viscoLiqSat) / volumenEspecificoMasico;
            conductividadTermica = (volVapSat * conduVapSat + volLiqSat * conduLiqSat) / volumenEspecificoMasico;
            densidad = 1.0 / volumenEspecificoMasico;
            viscosidadCinematica = viscosidad / densidad;
            return tSat;
        }


        double CalcularRegion4ps(double pp, double ss)
        {
            double pSat27315K = PresionDeSaturacion(273.15);
            double pSat62315K = PresionDeSaturacion(623.15);
            double volLiqSat = 0.0, volVapSat = 0.0, enerIntLiqSat = 0.0, enerIntVapSat = 0.0, entaLiqSat = 0.0, entaVapSat = 0.0, CpLiqSat = 0.0, CpVapSat = 0.0;
            double entroLiqSat = 0.0, entroVapSat = 0.0, viscoLiqSat = 0.0, viscoVapSat = 0.0, conduLiqSat = 0.0, conduVapSat = 0.0, CvLiqSat = 0.0, CvVapSat = 0.0;
            double calidad = 0.0, tSat = 0.0, densidad = 0.0, rhoLiqSat = 0.0, rhoVapSat = 0.0, volEspec = 0.0, volCritico = 1.0 / RHOCW;
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                tSat = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, tSat);
                entaLiqSat = entalpiaMasica;
                enerIntLiqSat = energiaInternaMasica;
                volLiqSat = volumenEspecificoMasico;
                CpLiqSat = CpMasico;
                entroLiqSat = entropiaMasica;
                viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                densidad = 1.0 / volLiqSat;
                conduLiqSat = thermalConductivity(densidad, tSat);
                CvLiqSat = CvMasico;
                CalcularRegion2(pp, tSat);
                entaVapSat = entalpiaMasica;
                enerIntVapSat = energiaInternaMasica;
                volVapSat = volumenEspecificoMasico;
                densidad = 1.0 / volVapSat;
                CpVapSat = CpMasico;
                entroVapSat = entropiaMasica;
                viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                conduVapSat = thermalConductivity(densidad, tSat);
                CvVapSat = CvMasico;
            }
            else if (pp > pSat62315K && pp < 22.064)
            {
                tSat = TemperaturaDeSaturacion(pp);
                volEspec = CalcularV3pt(pp, tSat);
                if (volEspec < volCritico)
                {
                    volLiqSat = volEspec;
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoLiqSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat);
                    CvLiqSat = CvMasico;
                    volVapSat = CalcularV3pt(pp, tSat + 0.00001);
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat + 0.00001, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat + 0.00001);
                    CvVapSat = CvMasico;
                }
                else if (volEspec > volCritico)
                {
                    volVapSat = volEspec;
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvMasico;
                    volLiqSat = CalcularV3pt(pp, tSat - 0.00001);
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat - 0.00001, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat + 0.00001);
                    CvLiqSat = CvMasico;
                }
                else if (volEspec == volCritico)
                {
                    volVapSat = volLiqSat = volEspec;
                    rhoVapSat = rhoLiqSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entaLiqSat = entalpiaMasica;
                    enerIntVapSat = enerIntLiqSat = energiaInternaMasica;
                    CpVapSat = CpLiqSat = CpMasico;
                    entroVapSat = entroLiqSat = entropiaMasica;
                    viscoVapSat = viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = conduLiqSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvLiqSat = CvMasico;
                }

            }
            calidad = (ss - entroLiqSat) / (entroVapSat - entroLiqSat);
            energiaInternaMasica = calidad * enerIntVapSat + (1.0 - calidad) * enerIntLiqSat;
            volumenEspecificoMasico = calidad * volVapSat + (1.0 - calidad) * volLiqSat;
            CpMasico = calidad * CpVapSat + (1.0 - calidad) * CpLiqSat;
            entalpiaMasica = calidad * entaVapSat + (1.0 - calidad) * entaLiqSat;
            CvMasico = calidad * CvVapSat + (1.0 - calidad) * CvLiqSat;
            viscosidad = (volVapSat * viscoVapSat + volLiqSat * viscoLiqSat) / volumenEspecificoMasico;
            conductividadTermica = (volVapSat * conduVapSat + volLiqSat * conduLiqSat) / volumenEspecificoMasico;
            densidad = 1.0 / volumenEspecificoMasico;
            viscosidadCinematica = viscosidad / densidad;
            return tSat;
        }


        double CalcularFlashPresionCalidad(double pp, double xx)
        {
            pp /= 10.0;
            double pSat27315K = PresionDeSaturacion(273.15);
            double pSat62315K = PresionDeSaturacion(623.15);
            double volLiqSat = 0.0, volVapSat = 0.0, enerIntLiqSat = 0.0, enerIntVapSat = 0.0, entaLiqSat = 0.0, entaVapSat = 0.0, CpLiqSat = 0.0, CpVapSat = 0.0;
            double entroLiqSat = 0.0, entroVapSat = 0.0, viscoLiqSat = 0.0, viscoVapSat = 0.0, conduLiqSat = 0.0, conduVapSat = 0.0, CvLiqSat = 0.0, CvVapSat = 0.0;
            double calidad = 0.0, tSat = 0.0, densidad = 0.0, rhoLiqSat = 0.0, rhoVapSat = 0.0, volEspec = 0.0, volCritico = 1.0 / RHOCW;
            calidad = xx;
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                tSat = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, tSat);
                entaLiqSat = entalpiaMasica;
                enerIntLiqSat = energiaInternaMasica;
                volLiqSat = volumenEspecificoMasico;
                CpLiqSat = CpMasico;
                entroLiqSat = entropiaMasica;
                viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                densidad = 1.0 / volLiqSat;
                conduLiqSat = thermalConductivity(densidad, tSat);
                CvLiqSat = CvMasico;
                CalcularRegion2(pp, tSat);
                entaVapSat = entalpiaMasica;
                enerIntVapSat = energiaInternaMasica;
                volVapSat = volumenEspecificoMasico;
                densidad = 1.0 / volVapSat;
                CpVapSat = CpMasico;
                entroVapSat = entropiaMasica;
                viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                conduVapSat = thermalConductivity(densidad, tSat);
                CvVapSat = CvMasico;
            }
            else if (pp > pSat62315K && pp < 22.064)
            {
                tSat = TemperaturaDeSaturacion(pp);
                volEspec = CalcularV3pt(pp, tSat);
                if (volEspec < volCritico)
                {
                    volLiqSat = volEspec;
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoLiqSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat);
                    CvLiqSat = CvMasico;
                    volVapSat = CalcularV3pt(pp, tSat + 0.00001);
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat + 0.00001, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat + 0.00001);
                    CvVapSat = CvMasico;
                }
                else if (volEspec > volCritico)
                {
                    volVapSat = volEspec;
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvMasico;
                    volLiqSat = CalcularV3pt(pp, tSat - 0.00001);
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat - 0.00001, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat + 0.00001);
                    CvLiqSat = CvMasico;
                }
                else if (volEspec == volCritico)
                {
                    volVapSat = volLiqSat = volEspec;
                    rhoVapSat = rhoLiqSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entaLiqSat = entalpiaMasica;
                    enerIntVapSat = enerIntLiqSat = energiaInternaMasica;
                    CpVapSat = CpLiqSat = CpMasico;
                    entroVapSat = entroLiqSat = entropiaMasica;
                    viscoVapSat = viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = conduLiqSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvLiqSat = CvMasico;
                }

            }
            entropiaMasica = calidad * entroVapSat + (1.0 - calidad) * entroLiqSat;
            energiaInternaMasica = calidad * enerIntVapSat + (1.0 - calidad) * enerIntLiqSat;
            volumenEspecificoMasico = calidad * volVapSat + (1.0 - calidad) * volLiqSat;
            CpMasico = calidad * CpVapSat + (1.0 - calidad) * CpLiqSat;
            entalpiaMasica = calidad * entaVapSat + (1.0 - calidad) * entaLiqSat;
            CvMasico = calidad * CvVapSat + (1.0 - calidad) * CvLiqSat;
            viscosidad = (volVapSat * viscoVapSat + volLiqSat * viscoLiqSat) / volumenEspecificoMasico;
            conductividadTermica = (volVapSat * conduVapSat + volLiqSat * conduLiqSat) / volumenEspecificoMasico;
            densidad = 1.0 / volumenEspecificoMasico;
            viscosidadCinematica = viscosidad / densidad;
            return tSat;
        }

        double CalcularFlashTemperaturaCalidad(double tt, double xx)
        {
            double pSat27315K = PresionDeSaturacion(273.15);
            double pSat62315K = PresionDeSaturacion(623.15), pp;
            double volLiqSat = 0.0, volVapSat = 0.0, enerIntLiqSat = 0.0, enerIntVapSat = 0.0, entaLiqSat = 0.0, entaVapSat = 0.0, CpLiqSat = 0.0, CpVapSat = 0.0;
            double entroLiqSat = 0.0, entroVapSat = 0.0, viscoLiqSat = 0.0, viscoVapSat = 0.0, conduLiqSat = 0.0, conduVapSat = 0.0, CvLiqSat = 0.0, CvVapSat = 0.0;
            double calidad = 0.0, tSat = 0.0, densidad = 0.0, rhoLiqSat = 0.0, rhoVapSat = 0.0, volEspec = 0.0, volCritico = 1.0 / RHOCW;
            calidad = xx;
            pp = PresionDeSaturacion(tt);
            if (pp >= pSat27315K && pp <= pSat62315K)
            {
                tSat = TemperaturaDeSaturacion(pp);
                CalcularRegion1(pp, tSat);
                entaLiqSat = entalpiaMasica;
                enerIntLiqSat = energiaInternaMasica;
                volLiqSat = volumenEspecificoMasico;
                CpLiqSat = CpMasico;
                entroLiqSat = entropiaMasica;
                viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                densidad = 1.0 / volLiqSat;
                conduLiqSat = thermalConductivity(densidad, tSat);
                CvLiqSat = CvMasico;
                CalcularRegion2(pp, tSat);
                entaVapSat = entalpiaMasica;
                enerIntVapSat = energiaInternaMasica;
                volVapSat = volumenEspecificoMasico;
                densidad = 1.0 / volVapSat;
                CpVapSat = CpMasico;
                entroVapSat = entropiaMasica;
                viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                conduVapSat = thermalConductivity(densidad, tSat);
                CvVapSat = CvMasico;
            }
            else if (pp > pSat62315K && pp < 22.064)
            {
                tSat = TemperaturaDeSaturacion(pp);
                volEspec = CalcularV3pt(pp, tSat);
                if (volEspec < volCritico)
                {
                    volLiqSat = volEspec;
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoLiqSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat);
                    CvLiqSat = CvMasico;
                    volVapSat = CalcularV3pt(pp, tSat + 0.00001);
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat + 0.00001, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat + 0.00001);
                    CvVapSat = CvMasico;
                }
                else if (volEspec > volCritico)
                {
                    volVapSat = volEspec;
                    rhoVapSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entalpiaMasica;
                    enerIntVapSat = energiaInternaMasica;
                    CpVapSat = CpMasico;
                    entroVapSat = entropiaMasica;
                    viscoVapSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvMasico;
                    volLiqSat = CalcularV3pt(pp, tSat - 0.00001);
                    rhoLiqSat = 1.0 / volLiqSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaLiqSat = entalpiaMasica;
                    enerIntLiqSat = energiaInternaMasica;
                    CpLiqSat = CpMasico;
                    entroLiqSat = entropiaMasica;
                    viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat - 0.00001, volLiqSat);
                    conduLiqSat = thermalConductivity(rhoLiqSat, tSat + 0.00001);
                    CvLiqSat = CvMasico;
                }
                else if (volEspec == volCritico)
                {
                    volVapSat = volLiqSat = volEspec;
                    rhoVapSat = rhoLiqSat = 1.0 / volVapSat;
                    CalcularRegion3(rhoVapSat, tSat);
                    entaVapSat = entaLiqSat = entalpiaMasica;
                    enerIntVapSat = enerIntLiqSat = energiaInternaMasica;
                    CpVapSat = CpLiqSat = CpMasico;
                    entroVapSat = entroLiqSat = entropiaMasica;
                    viscoVapSat = viscoLiqSat = ViscosidadDinamicaDeVolumenEspecifico(pp, tSat, volVapSat);
                    conduVapSat = conduLiqSat = thermalConductivity(rhoVapSat, tSat);
                    CvVapSat = CvLiqSat = CvMasico;
                }

            }
            entropiaMasica = calidad * entroVapSat + (1.0 - calidad) * entroLiqSat;
            energiaInternaMasica = calidad * enerIntVapSat + (1.0 - calidad) * enerIntLiqSat;
            volumenEspecificoMasico = calidad * volVapSat + (1.0 - calidad) * volLiqSat;
            CpMasico = calidad * CpVapSat + (1.0 - calidad) * CpLiqSat;
            entalpiaMasica = calidad * entaVapSat + (1.0 - calidad) * entaLiqSat;
            CvMasico = calidad * CvVapSat + (1.0 - calidad) * CvLiqSat;
            viscosidad = (volVapSat * viscoVapSat + volLiqSat * viscoLiqSat) / volumenEspecificoMasico;
            conductividadTermica = (volVapSat * conduVapSat + volLiqSat * conduLiqSat) / volumenEspecificoMasico;
            densidad = 1.0 / volumenEspecificoMasico;
            viscosidadCinematica = viscosidad / densidad;
            return pp;
        }


        double CalcularFlashPresionEntropia(double pp, double ss)
        {
            pp /= 10.0;
            double Tps = 0.0, Vph = 0.0;
            int iRegion = BoundariesForPSBack(pp, ss); ;
            switch (iRegion)
            {
                case 1:
                    Tps = CalcularT1ps(pp, ss);
                    CalcularRegion1(pp, Tps);
                    break;
                case 2:
                    Tps = CalcularT2ps(pp, ss);
                    CalcularRegion2(pp, Tps);
                    break;
                case 3:
                    Tps = CalcularT3ph(pp, ss);
                    Vph = CalcularV3ps(pp, ss);
                    densidadMasica = 1.0 / Vph;
                    volumenEspecificoMasico = Vph;
                    CalcularRegion3(densidadMasica, Tps);
                    break;
                case 4:
                    Tps = CalcularRegion4ps(pp, ss);
                    break;
            }
            volumenEspecificoMolar = volumenEspecificoMasico * WM;
            entalpiaMolar = entalpiaMasica * WM;
            energiaInternaMolar = energiaInternaMasica * WM;
            entropiaMolar = entropiaMasica * WM;
            CpMolar = CpMasico * WM;
            CvMolar = CvMasico * WM;
            densidadMasica = 1.0 / volumenEspecificoMasico;
            densidadMolar = densidadMasica * WM;
            viscosidad = ViscosidadDinamicaDeVolumenEspecifico(pp, Tps, volumenEspecificoMasico);
            conductividadTermica = thermalConductivity(densidadMasica, Tps);
            tensionSuperficial = SurfaceTension(Tps);
            viscosidadCinematica = viscosidad / densidadMasica;
            return Tps;
        }

        double CalcularT3ab(double pp)
        {
            double T3ab = 0.0;
            int i;
            double[] no = { 0.154793642129415e4, -0.187661219490113e3, 0.213144632222113e2,
-0.191887498864292e4, 0.918419702359447e3 };
            int[] I = { 0, 1, 2, -1, -2 };
            for (i = 0; i < 5; i++)
                T3ab += no[i] * Math.Pow(Math.Log(pp), I[i]);
            return T3ab;
        }

        double CalcularT3cd(double pp)
        {
            double T3cd = 0.0;
            int i;
            double[] no = { 0.585276966696349e3, 0.278233532206915e1, -0.127283549295878e-1,
    0.159090746562729e-3 };
            int[] I = { 0, 1, 2, 3 };
            for (i = 0; i < 4; i++)
                T3cd += no[i] * Math.Pow(pp, I[i]);
            return T3cd;
        }

        double CalcularT3ef(double pp)
        {
            double T3ef = 0;
            T3ef = 647.096 + 3.727888004 * (pp - 22.064);
            return T3ef;
        }

        double CalcularT3gh(double pp)
        {
            double T3gh = 0.0;
            int i;
            double[] no = { -0.249284240900418e5, 0.428143584791546e4, -0.269029173140130e3,
    0.751608051114157e1, -0.787105249910383e-1 };
            int[] I = { 0, 1, 2, 3, 4 };
            for (i = 0; i < 5; i++)
                T3gh += no[i] * Math.Pow(pp, I[i]);
            return T3gh;
        }

        double CalcularT3ij(double pp)
        {
            double T3ij = 0.0;
            int i;
            double[] no = { 0.584814781649163e3, -0.616179320924617, 0.260763050899562,
    -0.587071076864459e-2, 0.515308185433082e-4 };
            int[] I = { 0, 1, 2, 3, 4 };
            for (i = 0; i < 5; i++)
                T3ij += no[i] * Math.Pow(pp, I[i]);
            return T3ij;
        }


        double CalcularT3jk(double pp)
        {
            double T3jk = 0.0;
            int i;
            double[] no = { 0.617229772068439e3, -0.770600270141675e1, 0.697072596851896,
    -0.157391839848015e-1, 0.137897492684194e-3 };
            int[] I = { 0, 1, 2, 3, 4 };
            for (i = 0; i < 5; i++)
                T3jk += no[i] * Math.Pow(pp, I[i]);
            return T3jk;
        }


        double CalcularT3mn(double pp)
        {
            double T3mn = 0.0;
            int i;
            double[] no = { 0.535339483742384e3, 0.761978122720128e1, -0.158365725441648, 0.192871054508108e-2 };
            int[] I = { 0, 1, 2, 3 };
            for (i = 0; i < 4; i++)
                T3mn += no[i] * Math.Pow(pp, I[i]);
            return T3mn;
        }


        double CalcularT3op(double pp)
        {
            double T3op = 0.0;
            int i;
            double[] no = { 0.969461372400213e3, -0.332500170441278e3, 0.642859598466067e2, 0.773845935768222e3, -0.152313732937084e4 };
            int[] I = { 0, 1, 2, -1, -2 };
            for (i = 0; i < 5; i++)
                T3op += no[i] * Math.Pow(Math.Log(pp), I[i]);
            return T3op;
        }


        double CalcularT3qu(double pp)
        {
            double T3qu = 0.0;
            int i;
            double[] no = { 0.565603648239126e3, 0.529062258221222e1, -0.102020639611016, 0.122240301070145e-2 };
            int[] I = { 0, 1, 2, 3 };
            for (i = 0; i < 4; i++)
                T3qu += no[i] * Math.Pow(pp, I[i]);
            return T3qu;
        }


        double CalcularT3rx(double pp)
        {
            double T3rx = 0.0;
            int i;
            double[] no = { 0.584561202520006e3, -0.102961025163669e1, 0.243293362700452, -0.294905044740799e-2 };
            int[] I = { 0, 1, 2, 3 };
            for (i = 0; i < 4; i++)
                T3rx += no[i] * Math.Pow(pp, I[i]);
            return T3rx;
        }

        double EnRegion3aParaCalcularV3(double pp, double tt)
        {
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double vStar = 0.0024, pStar = 100.0, tStar = 760.0, a = 0.085, b = 0.817, c = 1, d = 1, e = 1;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int N = 30, i = 0;
            double[] no = { 0.110879558823853e-2, 0.572616740810616e3, -0.767051948380852e5,
    -0.253321069529674e-1, 0.628008049345689e4, 0.234105654131876e6, 0.216867826045856,
    -0.156237904341963e3, -0.269893956176613e5, -0.180407100085505e-3, 0.116732227668261e-2,
    0.266987040856040e2, 0.282776617243286e5, -0.242431520029523e4, 0.435217323022733e-3,
    -0.122494831387441e-1, 0.179357604019989e1, 0.442729521058314e2, -0.593223489018342e-2,
    0.453186261685774, 0.135825703129140e1, 0.408748415856745e-1, 0.474686397863312,
    0.118646814997915e1, 0.546987265727549, 0.195266770452643, -0.502268790869663e-1,
    -0.369645308193377, 0.633828037528420e-2, 0.797441793901017e-1 };
            double[] I = { -12, -12, -12, -10, -10, -10, -8, -8, -8, -6, -5, -5, -5, -4, -3, -3, -3, -3, -2, -2, -2, -1, -1, -1, 0, 0, 1, 1, 2, 2 };
            double[] J = { 5, 10, 12, 5, 10, 12, 5, 8, 10, 1, 1, 5, 10, 8, 0, 1, 3, 6, 0, 2, 3, 0, 1, 2, 0, 1, 0, 2, 0, 2 };
            for (i = 0; i < 30; i++)
            {
                dpa = p1 - a;
                dtb = teta - b;
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }

        double EnRegion3bParaCalcularV3(double pp, double tt)
        {
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double vStar = 0.0041, pStar = 100.0, tStar = 860.0, a = 0.280, b = 0.779, c = 1, d = 1, e = 1;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int N = 32, i;
            double[] no = { -0.827670470003621e-1, 0.416887126010565e2, 0.483651982197059e-1,
    -0.291032084950276e5, -0.111422582236948e3, -0.202300083904014e-1, 0.294002509338515e3,
    0.140244997609658e3, -0.344384158811459e3, 0.361182452612149e3, -0.140699677420738e4,
    -0.202023902676481e-2, 0.171346792457471e3, -0.425597804058632e1, 0.691346085000334e-5,
    0.151140509678925e-2, -0.416375290166236e-1, -0.413754957011042e2, -0.506673295721637e2,
    -0.572212965569023e-3, 0.608817368401785e1, 0.239600660256161e2, 0.122261479925384e-1,
    0.216356057692938e1, 0.398198903368642, -0.116892827834085, -0.102845919373532, -0.492676637589284, 0.655540456406790e-1, -0.240462535078530, -0.269798180310075e-1, 0.128369435967012 };
            int[] I = { -12, -12, -10, -10, -8, -6, -6, -6, -5, -5, -5, -4, -4, -4, -3, -3, -3, -3, -3, -2, -2, -2, -1, -1, 0, 0, 1, 1, 2, 3, 4, 4 };
            int[] J = { 10, 12, 8, 14, 8, 5, 6, 8, 5, 8, 10, 2, 4, 5, 0, 1, 2, 3, 5, 0, 2, 5, 0, 2, 0, 1, 0, 2, 0, 2, 0, 1 };
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 32; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            omega = suma;
            V3 = omega * vStar;
            return V3;

        }
        /*
        1 −12 6 0.311 967 788 763 030 × 101         19 −2 4 0.234 604 891 591 616 × 103
        2 −12 8 0.276 713 458 847 564 × 105         20 −2 5 0.377 515 668 966 951 × 104
        3 −12 10 0.322 583 103 403 269 × 108        21 −1 0 0.158 646 812 591 361 × 10–1
        4 −10 6 − 0.342 416 065 095 363 × 103       22 −1 1 0.707 906 336 241 843
        5 −10 8 − 0.899 732 529 907 377 × 106       23 −1 2 0.126 016 225 146 570 × 102
        6 −10 10 − 0.793 892 049 821 251 × 108      24 0 0 0.736 143 655 772 152
        7 −8 5 0.953 193 003 217 388 × 102          25 0 1 0.676 544 268 999 101
        8 −8 6 0.229 784 742 345 072 × 104          26 0 2 − 0.178 100 588 189 137 × 102
        9 −8 7 0.175 336 675 322 499 × 106          27 1 0 − 0.156 531 975 531 713
        10 −6 8 0.791 214 365 222 792 × 107         28 1 2 0.117 707 430 048 158 × 102
        11 −5 1 0.319 933 345 844 209 × 10–4        29 2 0 0.840 143 653 860 447 × 10–1
        12 −5 4 − 0.659 508 863 555 767 × 102       30 2 1 − 0.186 442 467 471 949
        13 −5 7 − 0.833 426 563 212 851 × 106       31 2 3 − 0.440 170 203 949 645 × 102
        14 −4 2 0.645 734 680 583 292 × 10–1        32 2 7 0.123 290 423 502 494 × 107
        15 −4 8 − 0.382 031 020 570 813 × 107       33 3 0 − 0.240 650 039 730 845 × 10–1
        16 −3 0 0.406 398 848 470 079 × 10–4        34 3 7 − 0.107 077 716 660 869 × 107
        17 −3 3 0.310 327 498 492 008 × 102         35 8 1 0.438 319 858 566 475 × 10–1
        18 −2 0 − 0.892 996 718 483 724 × 10–3*/

        double EnRegion3cParaCalcularV3(double pp, double tt)
        {
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double vStar = 0.0022, pStar = 40.0, tStar = 690.0, a = 0.259, b = 0.903, c = 1, d = 1, e = 1;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int N = 35, i = 0;
            double[] no = { 0.311967788763030e1, 0.276713458847564e5, 0.322583103403269e8, -0.342416065095363e3, -0.899732529907377e6, -0.793892049821251e8, 0.953193003217388e2, 0.229784742345072e4, 0.175336675322499e6, 0.791214365222792e7, 0.319933345844209e-4, -0.659508863555767e2,
    -0.833426563212851e6, 0.645734680583292e-1, -0.382031020570813e7, 0.406398848470079e-4,
    0.310327498492008e2, -0.892996718483724e-3, 0.234604891591616e3, 0.377515668966951e4,
    0.158646812591361e-1, 0.707906336241843, 0.126016225146570e2, 0.736143655772152, 0.676544268999101, -0.178100588189137e2, -0.156531975531713, 0.117707430048158e2, 0.840143653860447e-1,
    -0.186442467471949, -0.440170203949645e2, 0.123290423502494e7, -0.240650039730845e-1, -0.107077716660869e7, 0.438319858566475e-1 };
            int[] I = { -12, -12, -12, -10, -10, -10, -8, -8, -8, -6, -5, -5, -5, -4, -4, -3, -3, -2, -2, -2, -1, -1, -1, 0, 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 8 };
            int[] J = { 6, 8, 10, 6, 8, 10, 5, 6, 7, 8, 1, 4, 7, 2, 8, 0, 3, 0, 4, 5, 0, 1, 2, 0, 1, 2, 0, 2, 0, 1, 3, 7, 0, 7, 1 };
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 35; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3dParaCalcularV3(double pp, double tt)
        {
            double[] no = { -0.452484847171645e-9, 0.315210389538801e-4, -0.214991352047545e-2,
    0.508058874808345e3, -0.127123036845932e8, 0.115371133120497e13, -0.197805728776273e-15,
    0.241554806033972e-10, -0.156481703640525e-5, 0.277211346836625e-2, -0.203578994462286e2,
    0.144369489909053e7, -0.411254217946539e11, 0.623449786243773e-5, -0.221774281146038e2,
    -0.689315087933158e5, -0.195419525060713e8, 0.316373510564015e4, 0.224040754426988e7,
    -0.436701347922356e-5, -0.404213852833996e-3, -0.348153203414663e3, -0.385294213555289e6,
     0.135203700099403e-6, 0.134648383271089e-3, 0.125031835351736e6, 0.968123678455841e-1,
     0.225660517512438e3, -0.190102435341872e-3, -0.299628410819229e-1, 0.500833915372121e-2,
     0.387842482998411, -0.138535367777182e4, 0.870745245971773, 0.171946252068742e1,
     -0.326650121426383e-1, 0.498044171727877e4, 0.551478022765087e-2 };
            int[] I = { -12, -12, -12, -12, -12, -12, -10, -10, -10, -10, -10, -10, -10, -8, -8, -8, -8, -6, -6, -5, -5, -5, -5, -4, -4, -4, -3, -3, -2, -2, -1, -1, -1, 0, 0, 1, 1, 3 };
            int[] J = { 4, 6, 7, 10, 12, 16, 0, 2, 4, 6, 8, 10, 14, 3, 7, 8, 10, 6, 8, 1, 2, 5, 7, 0, 1, 7, 2, 4, 0, 1, 0, 1, 5, 0, 2, 0, 6, 0 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double vStar = 0.0029, pStar = 40.0, tStar = 690.0, a = 0.559, b = 0.939, c = 1, d = 1, e = 4;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 38; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3eParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0032, pStar = 40.0, tStar = 710.0, a = 0.587, b = 0.918, c = 1, d = 1, e = 1;
            int N = 29;
            double[] no = { 0.715815808404721e9, -0.114328360753449e12, 0.376531002015720e-11,
    -0.903983668691157e-4, 0.665695908836252e6, 0.535364174960127e10, 0.794977402335603e11,
    0.922230563421437e2, -0.142586073991215e6,  -0.111796381424162e7, 0.896121629640760e4,
    -0.669989239070491e4, 0.451242538486834e-2, -0.339731325977713e2, -0.120523111552278e1,
    0.475992667717124e5, -0.266627750390341e6, -0.153314954386524e-3, 0.305638404828265,
    0.123654999499486e3,-0.104390794213011e4, -0.157496516174308e-1, 0.685331118940253,
    0.178373462873903e1, -0.544674124878910, 0.204529931318843e4, -0.228342359328752e5,
    0.413197481515899, -0.341931835910405e2 };
            int[] I = { -12,-12,-10,-10,-10,-10,-10,-8,-8,-8,-6,-5,-4,-4,-3, -3,
        -3,-2,-2,-2,-2,-1,0,0,1,1,1,2,2 };
            int[] J = { 14, 16, 3, 6, 10, 14, 16, 7, 8, 10, 6, 6, 2, 4, 2, 6, 7, 0, 1, 3, 4, 0, 0, 1, 0, 4, 6, 0, 2 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 29; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3fParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0064, pStar = 40.0, tStar = 730.0, a = 0.587, b = 0.891, c = 0.5, d = 1, e = 1;
            int N = 42;
            double[] no = { -0.251756547792325e-7, 0.601307193668763e-5, -0.100615977450049e-2,
    0.999969140252192, 0.214107759236486e1, -0.165175571959086e2, -0.141987303638727e-2,
    0.269251915156554e1, 0.349741815858722e2, -0.300208695771783e2,-0.131546288252539e1,
    -0.839091277286169e1, 0.181545608337015e-9, -0.591099206478909e-3, 0.152115067087106e1,
    0.252956470663225e-4, 0.100726265203786e-14, -0.149774533860650e1, -0.793940970562969e-9,
    -0.150290891264717e-3, 0.151205531275133e1, 0.470942606221652e-5, 0.195049710391712e-12,
    -0.911627886266077e-8, 0.604374640201265e-3, -0.225132933900136e-15, 0.610916973582981e-11,
    -0.303063908043404e-6, -0.137796070798409e-4, -0.919296736666106e-3, 0.639288223132545e-9,
    0.753259479898699e-6, -0.400321478682929e-12, 0.756140294351614e-8, -0.912082054034891e-11,
    -0.237612381140539e-7, 0.269586010591874e-4, -0.732828135157839e-10, 0.241995578306660e-9,
    -0.405735532730322e-3, 0.189424143498011e-9, -0.486632965074563e-9 };
            int[] I = { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 3, 3, 4, 5, 5, 6, 7, 7, 10, 12, 12, 12, 14, 14, 14, 14, 14, 16, 16, 18, 18, 20, 20, 20, 22, 24, 24, 28, 32 };
            int[] J = { -3, -2, -1, 0, 1, 2, -1, 1, 2, 3, 0, 1, -5, -2, 0, -3, -8, 1, -6, -4, 1, -6, -10, -8, -4, -12, -10, -8, -6, -4, -10, -8, -12, -10, -12, -10, -6, -12, -12, -4, -12, -12 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = Math.Sqrt(p1 - a);
            dtb = (teta - b);

            for (i = 0; i < 42; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3gParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0027, pStar = 25.0, tStar = 660.0, a = 0.872, b = 0.971, c = 1, d = 1, e = 4;
            int N = 38;
            double[] no = { 0.412209020652996e-4, -0.114987238280587e7, 0.948180885032080e10,
    -0.195788865718971e18, 0.496250704871300e25, -0.105549884548496e29, -0.758642165988278e12,
    -0.922172769596101e23, 0.725379072059348e30, -0.617718249205859e2, 0.107555033344858e5,
    -0.379545802336487e8, 0.228646846221831e12, -0.499741093010619e7, -0.280214310054101e31,
    0.104915406769586e7, 0.613754229168619e28, 0.80205671552378e32, -0.298617819828065e8,
    -0.910782540134681e2, 0.135033227281565e6, -0.712949383408211e19, -0.104578785289542e37,
    0.304331584444093e2, 0.59325079795445e10, -0.364174062110798e28, 0.921791403532461,
    -0.337693609657471, -0.724644143758508e2, -0.110480239272601, 0.536516031875059e1,
    -0.291441872156205e4, 0.616338176535305e40, -0.120889175861180e39, 0.818396024524612e23,
    0.940781944835829e9, -0.367279669545448e5, -0.837513931798655e16 };
            double[] I = { -12, -12, -12, -12, -12, -12, -10, -10, -10, -8, -8, -8, -8, -6, -6, -5, -5, -4, -3, -2, -2, -2, -2, -1, -1, -1, 0, 0, 0, 1, 1, 1, 3, 5, 6, 8, 10, 10 };
            double[] J = { 7, 12, 14, 18, 22, 24, 14, 20, 24, 7, 8, 10, 12, 8, 22, 7, 20, 22, 7, 3, 5, 14, 24, 2, 8, 18, 0, 1, 2, 0, 1, 3, 24, 22, 12, 3, 0, 6 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 38; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3hParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0032, pStar = 25.0, tStar = 660.0, a = 0.898, b = 0.983, c = 1, d = 1, e = 4;
            int N = 29;
            double[] no = { 0.561379678887577e-1, 0.774135421587083e10, 0.111482975877938e-8,
    -0.143987128208183e-2, 0.193696558764920e4, -0.605971823585005e9, 0.171951568124337e14,
    -0.185461154985145e17, 0.387851168078010e-16, -0.395464327846105e-13, -0.170875935679023e3,
    -0.212010620701220e4, 0.177683337348191e8, 0.110177443629575e2, -0.234396091693313e6,
    -0.656174421999594e7, 0.156362212977396e-4, -0.212946257021400e1, 0.135249306374858e2,
    0.177189164145813, 0.139499167345464e4, -0.703670932036388e-2, -0.152011044389648,
    0.981916922991113e-4, 0.147199658618076e-2, 0.202618487025578e2, 0.899345518944240,
    -0.211346402240858, 0.249971752957491e2 };
            int[] I = { -12, -12, -10, -10, -10, -10, -10, -10, -8, -8, -8, -8, -8, -6, -6, -6, -5, -5, -5, -4, -4, -3, -3, -2, -1, -1, 0, 1, 1 };
            int[] J = { 8, 12, 4, 6, 8, 10, 14, 16, 0, 1, 6, 7, 8, 4, 6, 8, 2, 3, 4, 2, 4, 1, 2, 0, 0, 2, 0, 0, 2 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 29; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3iParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0041, pStar = 25.0, tStar = 660.0, a = 0.910, b = 0.984, c = 0.5, d = 1, e = 4;
            int N = 42;
            double[] no = { 0.106905684359136e1, -0.148620857922333e1, 0.259862256980408e15,
    -0.446352055678749e-11, -0.566620757170032e-6, -0.235302885736849e-2, -0.269226321968839,
    0.922024992944392e1, 0.357633505503772e-11, -0.173942565562222e2, 0.700681785556229e-5,
    -0.267050351075768e-3, -0.231779669675624e1, -0.753533046979752e-12, 0.481337131452891e1,
    -0.223286270422356e22, -0.118746004987383e-4, 0.646412934136496e-2, -0.410588536330937e-9,
    0.422739537057241e20, 0.313698180473812e-12, 0.164395334345040e-23, -0.339823323754373e-5,
    -0.135268639905021e-1, -0.723252514211625e-14, 0.184386437538366e-8, -0.463959533752385e-1,
    -0.992263100376750e14, 0.688169154439335e-16, -0.222620998452197e-10, -0.540843018624083e-7,
    0.345570606200257e-2, 0.422275800304086e11, -0.126974478770487e-14, 0.927237985153679e-9,
    0.612670812016489e-13, -0.722693924063497e-11, -0.383669502636822e-3, 0.374684572410204e-3,
    -0.931976897511086e5, -0.247690616026922e-1, 0.658110546759474e2 };
            int[] I = { 0, 0, 0, 1, 1, 1, 1, 2, 3, 3, 4, 4, 4, 5, 5, 5, 7, 7, 8, 8, 10, 12, 12, 12, 14, 14, 14, 14, 18, 18, 18, 18, 18, 20, 20, 22, 24, 24, 32, 32, 36, 36 };
            int[] J = { 0, 1, 10, -4, -2, -1, 0, 0, -5, 0, -3, -2, -1, -6, -1, 12, -4, -3, -6, 10, -8, -12, -6, -4, -10, -8, -4, 5, -12, -10, -8, -6, 2, -12, -10, -12, -12, -8, -10, -5, -10, -8 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = Math.Sqrt(p1 - a);
            dtb = teta - b;
            for (i = 0; i < 42; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3jParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0054, pStar = 25.0, tStar = 670.0, a = 0.875, b = 0.964, c = 0.5, d = 1, e = 4;
            int N = 29;
            double[] no = { -0.111371317395540e-3, 0.100342892423685e1, 0.530615581928979e1,
    0.179058760078792e-5, -0.728541958464774e-3, -0.187576133371704e2, 0.199060874071849e-2,
    0.243574755377290e2, -0.177040785499444e-3, -0.259680385227130e-2, -0.198704578406823e3,
    0.738627790224287e-4, -0.236264692844138e-2, -0.161023121314333e1, 0.622322971786473e4,
    -0.960754116701669e-8, -0.510572269720488e-10, 0.767373781404211e-2, 0.663855469485254e-14,
    -0.717590735526745e-9, 0.146564542926508e-4, 0.309029474277013e-11, -0.464216300971708e-15,
    -0.390499637961161e-13, -0.236716126781431e-9, 0.454652854268717e-11, -0.422271787482497e-2,
    0.283911742354706e-10, 0.270929002720228e1 };
            int[] I = { 0, 0, 0, 1, 1, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 10, 12, 12, 14, 14, 14, 16, 18, 20, 20, 24, 24, 28, 28 };
            int[] J = { -1, 0, 1, -2, -1, 1, -1, 1, -2, -2, 2, -3, -2, 0, 3, -6, -8, -3, -10, -8, -5, -10, -12, -12, -10, -12, -6, -12, -5 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = Math.Sqrt(p1 - a);
            dtb = teta - b;
            for (i = 0; i < 29; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3kParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0077, pStar = 25.0, tStar = 680.0, a = 0.802, b = 0.935, c = 1, d = 1, e = 1;
            int N = 34;
            double[] no = { -0.401215699576099e9, 0.484501478318406e11, 0.394721471363678e-14,
    0.372629967374147e5,-0.369794374168666e-29, -0.380436407012452e-14, 0.475361629970233e-6,
    -0.879148916140706e-3, 0.844317863844331, 0.122433162656600e2, -0.104529634830279e3,
    0.589702771277429e3, -0.291026851164444e14, 0.170343072841850e-5, -0.277617606975748e-3,
    -0.344709605486686e1, 0.221333862447095e2, -0.194646110037079e3, 0.808354639772825e-15,
    -0.180845209145470e-10, -0.696664158132412e-5, -0.181057560300994e-2, 0.255830298579027e1,
    0.328913873658481e4, -0.173270241249904e-18, -0.661876792558034e-6, -0.395688923421250e-2,
    0.604203299819132e-17, -0.400879935920517e-13, 0.160751107464958e-8, 0.383719409025556e-4,
    -0.649565446702457e-14, -0.149095328506000e-11, 0.541449377329581e-8 };
            double[] I = { -2, -2, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 5, 5, 5, 6, 6, 6, 6, 8, 10, 12 };
            double[] J = { 10, 12, -5, 6, -12, -6, -2, -1, 0, 1, 2, 3, 14, -3, -2, 0, 1, 2, -8, -6, -3, -2, 0, 4, -12, -6, -3, -12, -10, -8, -5, -12, -12, -10 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 34; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }

        double EnRegion3lParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0026, pStar = 24.0, tStar = 650.0, a = 0.908, b = 0.989, c = 1, d = 1, e = 4;
            int N = 43;
            double[] no = { 0.260702058647537e10, -0.188277213604704e15, 0.554923870289667e19,
   -0.758966946387758e23, 0.413865186848908e27, -0.815038000738060e12, -0.381458260489955e33,
    -0.123239564600519e-1, 0.226095631437174e8, -0.495017809506720e12, 0.529482996422863e16,
    -0.444359478746295e23, 0.521635864527315e35, -0.487095672740742e55, -0.714430209937547e6,
    0.127868634615495, -0.100752127917598e2, 0.777451437960990e7, -0.108105480796471e25,
    -0.357578581169659e-5, -0.212857169423484e1, 0.270706111085238e30, -0.695953622348829e33,
    0.110609027472280, 0.721559163361354e2, -0.306367307532219e15, 0.265839618885530e-4,
    0.253392392889754e-1, -0.214443041836579e3, 0.937846601489667, 0.223184043101700e1,
    0.338401222509191e2, 0.494237237179718e21, -0.198068404154428, -0.141415349881140e31,
    -0.993862421613651e2, 0.125070534142731e3, -0.996473529004439e3, 0.473137909872765e5,
    0.116662121219322e33, -0.315874976271533e16, -0.445703369196945e33, 0.642794932373694e33 };
            int[] I = { -12, -12,-12,-12,-12,-10,-10,-8,-8,-8,-8,-8,-8,-8,-6,-5,-5,-4,-4,-3,-3,-3,
    -3,-2,-2,-2,-1,-1,-1,0,0,0,0,1,1,2,4,5,5,6,10,10,14 };
            int[] J = { 14,16,18,20,22,14,24,6,10,12,14,18,24,36,8,4,5,7,16,1,3,18,
    20,2,3,10,0,1,3,0,1,2,12,0,16,1,0,0,1,14,4,12,10 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 43; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3mParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0028, pStar = 23.0, tStar = 650.0, a = 1.0, b = 0.997, c = 1, d = 0.25, e = 1;
            int N = 40;
            double[] no = { 0.811384363481847, -0.56819910990094e4,-0.178657198172556e11,
    0.795537657613427e32, -0.814568209346872e5, -0.659774567602874e8, -0.152861148659302e11,
    -0.560165667510446e12, 0.458384828593949e6, -0.385754000383848e14, 0.453735800004273e8,
    0.939454935735563e12, 0.266572856432938e28, -0.547578313899097e10, 0.200725701112386e15,
    0.185007245563239e13, 0.185135446828337e9, -0.170451090076385e12, 0.157890366037614e15,     -0.202530509748774e16, 0.368193926183570e60, 0.170215539458936e18, 0.639234909918741e42,
    -0.821698160721956e15, -0.795260241872306e24, 0.233415869478510e18, -0.600079934586803e23, 0.594584382273384e25, 0.189461279349492e40, -0.810093428842645e46, 0.188813911076809e22,
    0.111052244098768e36, 0.291133958602503e46, -0.329421923951460e22, -0.137570282536696e26,
    0.181508996303902e28, -0.346865122768353e30, -0.211961148774260e38, -0.128617899887675e49,
    0.479817895699239e65 };
            int[] I = { 0, 3, 8, 20, 1, 3, 4, 5, 1, 6, 2, 4, 14, 2, 5, 3, 0, 1, 1, 1, 28, 2, 16, 0, 5, 0, 3, 4, 12, 16, 1, 8, 14, 0, 2, 3, 4, 8, 14, 24 };
            int[] J = { 0, 0, 0, 2, 5, 5, 5, 5, 6, 6, 7, 8, 8, 10, 10, 12, 14, 14, 18, 20, 20, 22, 22, 24, 24, 28, 28, 28, 28, 28, 32, 32, 32, 36, 36, 36, 36, 36, 36, 36 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = Math.Pow(teta - b, d);
            for (i = 0; i < 40; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3nParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0031, pStar = 23.0, tStar = 650.0, a = 0.976, b = 0.997;
            int N = 39;
            double[] no = { 0.280967799943151e-38, 0.614869006573609e-30, 0.582238667048942e-27,
    0.390628369238462e-22, 0.821445758255119e-20, 0.402137961842776e-14, 0.651718171878301e-12,
    -0.211773355803058e-7, 0.264953354380072e-2, -0.135031446451331e-31, -0.607246643970893e-23,
    -0.402352115234494e-18, -0.744938506925544e-16, 0.189917206526237e-12, 0.364975183508473e-5,
    0.177274872361946e-25, -0.334952758812999e-18, -0.421537726098389e-8, -0.391048167929649e-1,
    0.541276911564176e-13, 0.705412100773699e-11, 0.258585887897486e-8, -0.493111362030162e-10,
    -0.158649699894543e-5, -0.525037427886100, 0.220019901729615e-2, -0.643064132636925e-2,
    0.629154149015048e2, 0.135147318617061e3, 0.240560808321713e-6, -0.890763306701305e-3,
    -0.440209599407714e4, -0.302807107747776e3, 0.159158748314599e4, 0.232534272709876e6,
    -0.792681207132600e6, -0.869871364662769e11, 0.354542769185671e12, 0.400849240129329e15 };
            double[] I = { 0,3,4,6,7,10,12,14,18,0,3,5,6,8,12,0,3,7,12,2,
    3,4,2,4,7,4,3,5,6,0,0,3,1,0,1,0,1,0,1 };
            double[] J = { -12,-12,-12,-12,-12,-12,-12,-12,-12,-10,-10,-10,-10,-10,-10,-8,-8,-8,-8,-6,
    -6,-6,-5,-5,-5,-4,-3,-3,-3,-2,-1,-1,0,1,1,2,4,5,6 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 39; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = Math.Exp(suma);
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3oParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0034, pStar = 23.0, tStar = 650.0, a = 0.974, b = 0.996, c = 0.5, d = 1, e = 1;
            const int N = 24;
            double[] no = { 0.128746023979718e-34, -0.735234770382342e-11, 0.289078692149150e-2,
    0.244482731907223, 0.141733492030985e-23, -0.354533853059476e-28, -0.594539202901431e-17,
    -0.585188401782779e-8, 0.201377325411803e-5, 0.138647388209306e1, -0.173959365084772e-4,
    0.137680878349369e-2, 0.814897605805513e-14, 0.425596631351839e-25, -0.387449113787755e-17,
    0.139814747930240e-12, -0.171849638951521e-2, 0.641890529513296e-21, 0.118960578072018e-10,
    -0.155282762571611e-17, 0.233907907347507e-7, -0.174093247766213e-12, 0.377682649089149e-8,
    -0.516720236575302e-10 };
            double[] I = { 0, 0, 0, 2, 3, 4, 4, 4, 4, 4, 5, 5, 6, 7, 8, 8, 8, 10, 10, 14, 14, 20, 20, 24 };
            double[] J = { -12, -4, -1, -1, -10, -12, -8, -5, -4, -1, -4, -3, -8, -12, -10, -8, -4, -12, -8, -12, -8, -12, -10, -12 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = Math.Pow(p1 - a, c);
            dtb = teta - b;
            for (i = 0; i < 24; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3pParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0041, pStar = 23.0, tStar = 650.0, a = 0.972, b = 0.997, c = 0.5, d = 1, e = 1;
            double[] no = { -0.982825342010366e-4, 0.105145700850612e1, 0.116033094095084e3,
    0.324664750281543e4, -0.123592348610137e4, -0.561403450013495e-1, 0.856677401640869e-7,
    0.236313425393924e3, 0.972503292350109e-2, -0.103001994531927e1, -0.149653706199162e-8,
    -0.215743778861592e-4, -0.834452198291445e1, 0.586602660564988, 0.343480022104968e-25,
    0.816256095947021e-5, 0.294985697916798e-2, 0.711730466276584e-16, 0.400954763806941e-9,
     0.107766027032853e2, -0.409449599138182e-6, -0.729121307758902e-5, 0.677107970938909e-8,
    0.602745973022975e-7, -0.382323011855257e-10, 0.179946628317437e-2, -0.345042834640005e-3 };
            double[] I = { 0, 0, 0, 0, 1, 2, 3, 3, 4, 6, 7, 7, 8, 10, 12, 12, 12, 14, 14, 14, 16, 18, 20, 22, 24, 24, 36 };
            double[] J = { -1, 0, 1, 2, 1, -1, -3, 0, -2, -2, -5, -4, -2, -3, -12, -6, -5, -10, -8, -3, -8, -8, -10, -10, -12, -8, -12 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = Math.Pow(p1 - a, c);
            dtb = teta - b;
            for (i = 0; i < 27; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3qParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0022, pStar = 23.0, tStar = 650.0, a = 0.848, b = 0.983, c = 1, d = 1, e = 4;
            int N = 24;
            double[] no = { -0.820433843259950e5, 0.473271518461586e11, -0.805950021005413e-1,
    0.328600025435980e2, -0.356617029982490e4, -0.172985781433335e10, 0.351769232729192e8,
    -0.775489259985144e6, 0.710346691966018e-4, 0.993499883820274e5, -0.642094171904570,
    -0.612842816820083e4, 0.23280847298376e3, -0.142808220416837e-4, -0.643596060678456e-2,
    -0.428577227475614e1, 0.225689939161918e4, 0.100355651721510e-2, 0.333491455143516,
    0.109697576888873e1, 0.961917379376452, -0.838165632204598e-1, 0.247795908411492e1,
    -0.319114969006533e4 };
            double[] I = { -12, -12, -10, -10, -10, -10, -8, -6, -5, -5, -4, -4, -3, -2, -2, -2, -2, -1, -1, -1, 0, 1, 1, 1 };
            double[] J = { 10, 12, 6, 7, 8, 10, 8, 6, 2, 5, 3, 4, 3, 0, 1, 2, 4, 0, 1, 2, 0, 0, 1, 3 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 24; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3rParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0054, pStar = 23.0, tStar = 650.0, a = 0.874, b = 0.982, c = 1, d = 1, e = 1;
            double[] no = { 0.144165955660863e-2, -0.701438599628258e13, -0.830946716459219e-16,
    0.261975135368109, 0.393097214706245e3, -0.104334030654021e5, 0.490112654154211e9,
    -0.147104222772069e-3, 0.103602748043408e1, 0.305308890065089e1, -0.399745276971264e7,
    0.569233719593750e-11, -0.464923504407778e-1, -0.535400396512906e-17, 0.399988795693162e-12,
    -0.536479560201811e-6, 0.159536722411202e-1, 0.270303248860217e-14, 0.244247453858506e-7,
    -0.983430636716454e-5, 0.663513144224454e-1, -0.993456957845006e1, 0.546491323528491e3,
    -0.143365406393758e5, 0.150764974125511e6, -0.337209709340105e-9, 0.377501980025469e-8 };
            double[] I = { -8, -8, -3, -3, -3, -3, -3, 0, 0, 0, 0, 3, 3, 8, 8, 8, 8, 10, 10, 10, 10, 10, 10, 10, 10, 12, 14 };
            double[] J = { 6, 14, -3, 3, 4, 5, 8, -1, 0, 1, 5, -6, -2, -12, -10, -8, -5, -12, -10, -8, -6, -5, -4, -3, -2, -12, -12 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 27; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3sParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0022, pStar = 21.0, tStar = 640.0, a = 0.886, b = 0.990, c = 1, d = 1, e = 4;
            double[] no = { -0.532466612140254e23, 0.100415480000824e32, -0.191540001821367e30,
    0.105618377808847e17, 0.202281884477061e59, 0.884585472596134e8, 0.166540181638363e23,
    -0.313563197669111e6, -0.185662327545324e54, -0.624942093918942e-1, -0.504160724132590e10,
    0.187514491833092e5, 0.121399979993217e-2, 0.188317043049455e1, -0.167073503962060e4,
    0.965961650599775, 0.294885696802488e1, -0.653915627346115e5, 0.604012200163444e50,
    -0.198339358557937, -0.175984090163501e58, 0.356314881403987e1, -0.575991255144384e3,
    0.456213415338071e5, -0.109174044987829e8, 0.437796099975134e34, -0.616552611135792e46,
    0.193568768917797e10, 0.950898170425042e54 };
            double[] I = { -12, -12, -10, -8, -6, -5, -5, -4, -4, -3, -3, -2, -1, -1, -1, 0, 0, 0, 0, 1, 1, 3, 3, 3, 4, 4, 4, 5, 14 };
            double[] J = { 20, 24, 22, 14, 36, 8, 16, 6, 32, 3, 8, 4, 1, 2, 3, 0, 1, 4, 28, 0, 32, 0, 1, 2, 3, 18, 24, 4, 24 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 29; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion3tParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0088, pStar = 20.0, tStar = 650.0, a = 0.803, b = 1.02, c = 1, d = 1, e = 1;
            double[] no = { 0.155287249586268e1, 0.664235115009031e1, -0.289366236727210e4,
    -0.385923202309848e13, -0.291002915783761e1, -0.829088246858083e12, 0.176814899675218e1,
    -0.534686695713469e9, 0.160464608687834e18, 0.196435366560186e6, 0.156637427541729e13,
    -0.178154560260006e1, -0.229746237623692e16, 0.385659001648006e8, 0.110554446790543e10,
    -0.677073830687349e14, -0.327910592086523e31, -0.341552040860644e51, -0.527251339709047e21,
    0.245375640937055e24, -0.168776617209269e27, 0.358958955867578e29, -0.656475280339411e36, 0.355286045512301e39, 0.569021454413270e58, -0.700584546433113e48, -0.705772623326374e65, 0.166861176200148e53, -0.300475129680486e61, -0.668481295196808e51, 0.428432338620678e69,  -0.444227367758304e72, -0.281396013562745e77 };
            double[] I = { 0, 0, 0, 0, 1, 1, 2, 2, 2, 3, 3, 4, 4, 7, 7, 7, 7, 7, 10, 10, 10, 10, 10, 18, 20, 22, 22, 24, 28, 32, 32, 32, 36 };
            double[] J = { 0, 1, 4, 12, 0, 10, 0, 6, 14, 3, 8, 0, 10, 3, 4, 7, 20, 36, 10, 12, 14, 16, 22, 18, 32, 22, 36, 24, 28, 22, 32, 36, 36 };
            double omega = 0.0, suma = 0.0, dpa = 0.0, dtb = 0.0;
            double p1 = pp / pStar, teta = tt / tStar, V3 = 0.0;
            int i = 0;
            dpa = p1 - a;
            dtb = teta - b;
            for (i = 0; i < 33; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dtb, J[i]);
            }
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }

        String CalcularRegionParaV3PT(double pp, double tt)
        {
            double T3ab = CalcularT3ab(pp);//
            double T3cd = CalcularT3cd(pp);//
            double T3ef = CalcularT3ef(pp);//
            double T3gh = CalcularT3gh(pp);
            double T3ij = CalcularT3ij(pp);
            double T3jk = CalcularT3jk(pp);
            double T3op = CalcularT3op(pp);
            double T3mn = CalcularT3mn(pp);
            double T3qu = CalcularT3qu(pp);
            double T3rx = CalcularT3rx(pp);
            double T3uv = CalcularT3uv(pp);
            double T3wx = CalcularT3wx(pp);
            double Tsat = TemperaturaDeSaturacion(pp);
            if (pp > 40.0 && pp <= 100.0)
            {
                if (tt <= T3ab)
                    return ("3a");
                else if (tt > T3ab)
                    return ("3b");
            }
            else if (pp > 25.0 && pp <= 40.0)
            {
                if (tt <= T3cd)
                    return ("3c");
                else if (tt > T3ab && tt <= T3ef)
                    return ("3e");
                else if (tt > T3cd && tt <= T3ab)
                    return ("3d");
                else if (tt > T3ef)
                    return ("3f");

            }
            else if (pp > 23.5 && pp <= 25.0)
            {
                if (tt <= T3cd)
                    return ("3c");
                else if (tt > T3ef && tt <= T3ij)
                    return ("3i");
                else if (tt > T3cd && tt <= T3gh)
                    return ("3g");
                else if (tt > T3ij && tt <= T3jk)
                    return ("3j");
                else if (tt > T3gh && tt <= T3ef)
                    return ("3h");
                else if (tt > T3jk)
                    return ("3k");
            }
            else if (pp > 23.0 && pp <= 23.5)
            {
                if (tt <= T3cd)
                    return ("3c");

                else if (tt > T3ef && tt <= T3ij)
                    return ("3i");

                else if (tt > T3cd && tt <= T3gh)
                    return ("3l");

                else if (tt > T3ij && tt <= T3jk)
                    return ("3j");

                else if (tt > T3gh && tt <= T3ef)
                    return ("3h");

                else if (tt > T3jk)
                    return ("3k");
            }
            else if (pp > 22.5 && pp <= 23.0)
            {
                if (tt <= T3cd)
                    return ("3c");
                else if (tt > T3ef && tt <= T3op)
                    return ("3o");
                else if (tt > T3cd && tt <= T3gh)
                    return ("3l");
                else if (tt > T3op && tt <= T3ij)
                    return ("3p");
                else if (tt > T3gh && tt <= T3mn)
                    return ("3m");
                else if (tt > T3ij && tt <= T3jk)
                    return ("3j");
                else if (tt > T3mn && tt <= T3ef)
                    return ("3n");
                else if (tt > T3jk)
                    return ("3k");
            }
            else if (pp > 21.04336732 && pp <= 22.5)
            {
                if (tt >= T3qu && tt <= T3rx)
                {
                    if (pp <= 22.064) // Subcritico
                    {
                        if (tt < TemperaturaDeSaturacion(pp)) // Liquido
                        {
                            if (pp > 21.93161551 && pp <= 22.064)
                            {
                                if (tt > T3qu && tt <= T3uv)
                                    return ("3u");
                                else if (T3uv < tt)
                                    return ("3y");
                            }
                            else if (pp > PresionDeSaturacion(643.15) && pp <= 21.93161551)
                                if (tt > T3qu) return ("3u");
                        }
                        else if (tt >= TemperaturaDeSaturacion(pp))
                        {
                            if (pp > 21.90096265 && pp <= 22.064)
                            {
                                if (tt <= T3wx)
                                    return ("3z");
                                else if (tt > T3wx && tt >= T3rx)
                                    return ("3x");
                            }
                            else if (pp > PresionDeSaturacion(643.15) && pp <= 21.90096265)
                                if (tt <= T3rx) return ("3x");
                        }
                    }
                    else if (pp > 22.064)
                    {
                        if (pp > 22.064 && pp <= 22.11)
                        {
                            if (tt > T3qu && tt <= T3uv)
                                return ("3u");
                            else if (tt > T3uv && tt <= T3ef)
                                return ("3y");
                            else if (tt > T3ef && tt <= T3wx)
                                return ("3z");
                            else if (tt > T3wx && tt <= T3rx)
                                return ("3x");
                        }
                        else if (pp > 22.11 && pp <= 22.5)
                        {
                            if (tt > T3qu && tt <= T3uv)
                                return ("3u");
                            else if (tt > T3uv && tt <= T3ef)
                                return ("3v");
                            else if (tt > T3ef && tt <= T3wx)
                                return ("3w");
                            else if (tt > T3wx && tt <= T3rx)
                                return ("3x");
                        }
                    }
                }
                else if (tt <= T3cd)
                    return ("3c");

                else if (tt > T3rx && tt <= T3jk)
                    return ("3r");

                else if (tt > T3cd && tt <= T3qu)
                    return ("3q");

                else if (tt > T3jk)
                    return ("3k");
            }
            else if (pp > 20.5 && pp <= 21.04336732)
            {
                if (tt <= T3cd)
                    return ("3c");

                else if (tt > Tsat && tt <= T3jk)
                    return ("3r");

                else if (tt > T3cd && tt <= Tsat)
                    return ("3s");

                else if (tt > T3jk)
                    return ("3k");
            }
            else if (pp > 19.00881189 && pp <= 20.5)
            {
                if (tt <= T3cd)
                    return ("3c");

                else if (tt > T3cd && tt <= Tsat)
                    return ("3s");

                else if (tt >= Tsat)
                    return ("3t");
            }
            else if (pp > 16.52916425 && pp <= 19.00881189)
            {
                if (tt <= Tsat)
                    return ("3c");

                else if (tt >= Tsat)
                    return ("3t");
            }
            else if ((tt >= T3qu && tt <= T3rx) && (pp >= 21.04336732 && pp <= 22.5))
            {
                if (pp <= 22.064) // Subcritico
                {
                    if (tt < TemperaturaDeSaturacion(pp)) // Liquido
                    {
                        if (pp > 21.93161551 && pp <= 22.064)
                        {
                            if (tt > T3qu && tt <= T3uv)
                                return ("3u");
                            else if (T3uv < tt)
                                return ("3y");
                        }
                        else if (pp > PresionDeSaturacion(643.15) && pp <= 21.93161551)
                            if (tt > T3qu) return ("3u");
                    }
                    else if (tt >= TemperaturaDeSaturacion(pp))
                    {
                        if (pp > 21.90096265 && pp <= 22.064)
                        {
                            if (tt <= T3wx)
                                return ("3z");
                            else if (tt > T3wx && tt >= T3rx)
                                return ("3x");
                        }
                        else if (pp > PresionDeSaturacion(643.15) && pp <= 21.90096265)
                            if (tt <= T3rx) return ("3x");
                    }
                }
                else if (pp > 22.064)
                {
                    if (pp > 22.064 && pp <= 22.11)
                    {
                        if (tt > T3qu && tt <= T3uv)
                            return ("3u");
                        else if (tt > T3uv && tt <= T3ef)
                            return ("3y");
                        else if (tt > T3ef && tt <= T3wx)
                            return ("3z");
                        else if (tt > T3wx && tt <= T3rx)
                            return ("3x");
                    }
                    else if (pp > 22.11 && pp <= 22.5)
                    {
                        if (tt > T3qu && tt <= T3uv)
                            return ("3u");
                        else if (tt > T3uv && tt <= T3ef)
                            return ("3v");
                        else if (tt > T3ef && tt <= T3wx)
                            return ("3w");
                        else if (tt > T3wx && tt <= T3rx)
                            return ("3x");
                    }
                }
            }
            return ("");
        }

        double CalcularV3pt(double pp, double tt)
        {
            double V3 = 0.0;
            String ss = CalcularRegionParaV3PT(pp, tt);
            if (ss == "3a")
            {
                V3 = EnRegion3aParaCalcularV3(pp, tt);
            }
            else if (ss == "3b")
            {
                V3 = EnRegion3bParaCalcularV3(pp, tt);
            }
            else if (ss == "3c")
            {
                V3 = EnRegion3cParaCalcularV3(pp, tt);
            }
            else if (ss == "3d")
            {
                V3 = EnRegion3dParaCalcularV3(pp, tt);
            }
            else if (ss == "3e")
            {
                V3 = EnRegion3eParaCalcularV3(pp, tt);
            }
            else if (ss == "3f")
            {
                V3 = EnRegion3fParaCalcularV3(pp, tt);
            }
            else if (ss == "3g")
            {
                V3 = EnRegion3gParaCalcularV3(pp, tt);
            }
            else if (ss == "3h")
            {
                V3 = EnRegion3hParaCalcularV3(pp, tt);
            }
            else if (ss == "3i")
            {
                V3 = EnRegion3iParaCalcularV3(pp, tt);
            }
            else if (ss == "3j")
            {
                V3 = EnRegion3jParaCalcularV3(pp, tt);
            }
            else if (ss == "3k")
            {
                V3 = EnRegion3kParaCalcularV3(pp, tt);
            }
            else if (ss == "3l")
            {
                V3 = EnRegion3lParaCalcularV3(pp, tt);
            }
            else if (ss == "3m")
            {
                V3 = EnRegion3mParaCalcularV3(pp, tt);
            }
            else if (ss == "3n")
            {
                V3 = EnRegion3nParaCalcularV3(pp, tt);
            }
            else if (ss == "3o")
            {
                V3 = EnRegion3oParaCalcularV3(pp, tt);
            }
            else if (ss == "3p")
            {
                V3 = EnRegion3pParaCalcularV3(pp, tt);
            }
            else if (ss == "3q")
            {
                V3 = EnRegion3qParaCalcularV3(pp, tt);
            }

            else if (ss == "3r")
            {
                V3 = EnRegion3rParaCalcularV3(pp, tt);
            }
            else if (ss == "3s")
            {
                V3 = EnRegion3sParaCalcularV3(pp, tt);
            }
            else if (ss == "3t")
            {
                V3 = EnRegion3tParaCalcularV3(pp, tt);
            }
            else if (ss == "3u")
            {
                V3 = EnRegion_3u_ParaCalcularV3(pp, tt);
            }
            else if (ss == "3v")
            {
                V3 = EnRegion_3v_ParaCalcularV3(pp, tt);
            }
            else if (ss == "3w")
            {
                V3 = EnRegion_3w_ParaCalcularV3(pp, tt);
            }
            else if (ss == "3x")
            {
                V3 = EnRegion_3x_ParaCalcularV3(pp, tt);
            }
            else if (ss == "3y")
            {
                V3 = EnRegion_3y_ParaCalcularV3(pp, tt);
            }
            else if (ss == "3z")
            {
                V3 = EnRegion_3z_ParaCalcularV3(pp, tt);
            }
            return V3;
        }

        double CalcularT3uv(double pp)
        {
            double teta = 0.0;
            double p1 = pp;
            double[] no = { 0.528199646263062e3, 0.890579602135307e1, -0.222814134903755, 0.286791682263697e-2 };
            int[] I = { 0, 1, 2, 3 };
            int i;
            for (i = 0; i < 4; i++)
                teta += no[i] * Math.Pow(p1, I[i]);
            return teta;
        }

        double CalcularT3wx(double pp)
        {
            double teta = 0.0, p1 = pp;
            double[] no = { 0.728052609145380e1, 0.973505869861952e2, 0.147370491183191e2, 0.329196213998375e3, 0.873371668682417e3 };
            int[] I = { 0, 1, 2, -1, -2 };
            int i;
            for (i = 0; i < 5; i++)
                teta += no[i] * Math.Pow(Math.Log(p1), I[i]);
            return teta;
        }

        double EnRegion_3u_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0026, pStar = 23.0, tStar = 650.0, a = 0.902, b = 0.988;
            double[] no = { 0.122088349258355e18, 0.104216468608488e10, -0.882666931564652e16,
    0.259929510849499e20, 0.222612779142211e15, -0.878473585050085e18, -0.314432577551552e22,
    -0.216934916996285e13, 0.159079648196849e21, -0.339567617303423e3, 0.884387651337836e13,
    -0.843405926846418e21, 0.114178193518022e2, -0.122708229235641e-3, -0.106201671767107e3,
    0.903443213959313e25, -0.693996270370852e28, 0.648916718965575e-8, 0.718957567127851e4,
    0.105581745346187e-2, -0.651903203602581e15, -0.160116813274676e25, -0.510254294237837e-8,
    -0.152355388953402, 0.677143292290144e12, 0.276378438378930e15, 0.116862983141686e-1,
    -0.301426947980171e14, 0.169719813884840e-7, 0.104674840020929e27, -0.108016904560140e5,
    -0.990623601934295e-12, 0.536116483602738e7, 0.226145963747881e22, -0.488731565776210e-9,
    0.151001548880670e-4, -0.227700464643920e5, -0.781754507698846e28 };
            int[] I = { -12, -10, -10, -10, -8, -8, -8, -6, -6, -5, -5, -5, -3, -1, -1, -1, -1, 0, 0, 1, 2, 2, 3, 5, 5, 5, 6, 6, 8, 8, 10, 12, 12, 12, 14, 14, 14, 14 };
            int[] J = { 14, 10, 12, 14, 10, 12, 14, 8, 12, 4, 8, 12, 2, -1, 1, 12, 14, -3, 1, -2, 5, 10, -5, -4, 2, 3, -5, 2, -8, 8, -4, -12, -4, 4, -12, -10, -6, 6 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int c = 1, d = 1, e = 1, i = 0;
            for (i = 0; i < 38; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion_3v_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0031, pStar = 23.0, tStar = 650, a = 0.960, b = 0.995;
            double[] no = { -0.415652812061591e-54, 0.177441742924043e-60, -0.357078668203377e-54,
    0.359252213604114e-25, -0.259123736380269e2, 0.594619766193460e5, -0.624184007103158e11,
    0.313080299915944e17, 0.105006446192036e-8, -0.192824336984852e-5, 0.654144373749937e6,
    0.513117462865044e13, -0.697595750347391e19, -0.103977184454767e29, 0.119563135540666e-47,
    -0.436677034051655e-41, 0.926990036530639e-29, 0.587793105620748e21, 0.280375725094731e-17,
    -0.192359972440634e23, 0.742705723302738e27, -0.517429682450605e2, 0.820612048645469e7,
    -0.188214882341448e-8, 0.184587261114837e-1,-0.135830407782663e-5, -0.723681885626348e17,
    -0.223449194054124e27, -0.111526741826431e-34, 0.276032601145151e-28, 0.134856491567853e15,
    0.652440293345860e-9, 0.510655119774360e17, -0.468138358908732e32, -0.760667491183279e16,
    -0.417247986986821e-18, 0.312545677756104e14, -0.100375333864186e15, 0.247761392329058e27 };
            int[] I = { -10, -8, -6, -6, -6, -6, -6, -6, -5, -5, -5, -5, -5, -5, -4, -4, -4, -4, -3, -3, -3, -2, -2, -1, -1, 0, 0, 0, 1, 1, 3, 4, 4, 4, 5, 8, 10, 12, 14 };
            int[] J = { -8, -12, -12, -3, 5, 6, 8, 10, 1, 2, 6, 8, 10, 14, -12, -10, -6, 10, -3, 10, 12, 2, 4, -2, 0, -2, 6, 10, -12, -10, 3, -6, 3, 10, 2, -12, -2, -3, 1 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int c = 1, d = 1, e = 1, i = 0;
            for (i = 0; i < 39; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            omega = suma;
            V3 = omega * vStar;
            return V3;
        }
        double EnRegion_3w_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0039, pStar = 23.0, tStar = 650.0, a = 0.959, b = 0.995;
            int c = 1, d = 1, e = 4;
            double[] no = { -0.586219133817016e-7, -0.894460355005526e11, 0.531168037519774e-30,
    0.109892402329239, -0.575368389425212e-1, 0.228276853990249e5, -0.158548609655002e19,
    0.329865748576503e-27, -0.634987981190669e-24, 0.615762068640611e-8, -0.961109240985747e8,
    -0.406274286652625e-44, -0.471103725498077e-12, 0.725937724828145, 0.187768525763682e-38,
    -0.103308436323771e4, -0.662552816342168e-1, 0.579514041765710e3, 0.237416732616644e-26,
    0.271700235739893e-14, -0.907886213483600e2, -0.171242509570207e-36, 0.156792067854621e3,
    0.923261357901470, -0.597865988422577e1, 0.321988767636389e7, -0.399441390042203e-29,
    0.493429086046981e-7, 0.812036983370565e-19, -0.207610284654137e-11, -0.340821291419719e-6,
    0.542000573372233e-17, -0.856711586510214e-12, 0.266170454405981e-13, 0.858133791857099e-5 };
            int[] I = { -12, -12, -10, -10, -8, -8, -8, -6, -6, -6, -6, -5, -4, -4, -3, -3, -2, -2, -1, -1, -1, 0, 0, 1, 2, 2, 3, 3, 5, 5, 5, 8, 8, 10, 10 };
            int[] J = { 8, 14, -1, 8, 6, 8, 14, -4, -3, 2, 8, -10, -1, 3, -10, 3, 1, 2, -8, -4, 1, -12, 1, -1, -1, 2, -12, -5, -10, -8, -6, -12, -10, -12, -8 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int i = 0;
            for (i = 0; i < 35; i++)
            {
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            }
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;//3w
        }
        double EnRegion_3x_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0049, pStar = 23.0, tStar = 650.0, a = 0.910, b = 0.988;
            double[] no = { 0.377373741298151e19, -0.507100883722913e13, -0.103363225598860e16,
    0.184790814320773e-5, -0.924729378390945e-3, -0.425999562292738e24, -0.462307771873973e-12,
    0.107319065855767e22, 0.648662492280682e11, 0.244200600688281e1, -0.851535733484258e10,
    0.169894481433592e22, 0.215780222509020e-26, -0.320850551367334, -0.382642448458610e17,
    -0.275386077674421e-28, -0.563199253391666e6, -0.326068646279314e21, 0.397949001553184e14,
    0.100824008584757e-6, 0.162234569738433e5, -0.432355225319745e11, -0.592874245598610e12,
    0.133061647281106e1, 0.157338197797544e7, 0.258189614270853e14, 0.262413209706358e25,
   -0.920011937431142e-1, 0.220213765905426e-2, -0.110433759109547e2, 0.847004870612087e7,
    -0.592910695762536e9, -0.183027173269660e-4, 0.181339603516302, -0.119228759669889e4,
    0.430867658061468e7 };
            int[] I = { -8,-6,-5,-4,-4,-4,-3,-3,-1,0,0,0,1,1,2,3,3,3,
    4,5,5,5,6,8,8,8,8,10,12,12,12,12,14,14,14,14 };
            int[] J = { 14,10,10,1,2,14,-2,12,5,0,4,10,-10,-1,6,-12,0,8,
    3,-6,-2,1,1,-6,-3,1,8,-8,-10,-8,-5,-4,-12,-10,-8,-6 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int c = 1, d = 1, e = 1, i = 0;
            for (i = 0; i < 38; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            omega = suma;
            V3 = omega * vStar;
            return V3;//3x
        }


        double EnRegion_3y_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0031, pStar = 22.0, tStar = 650.0, a = 0.996, b = 0.994;
            double c = 1, d = 1, e = 4;
            double[] no = { -0.525597995024633e-9, 0.583441305228407e4, -0.134778968457925e17,
    0.118973500934212e26, -0.159096490904708e27, -0.315839902302021e-6, 0.496212197158239e3,
    0.327777227273171e19, -0.527114657850696e22, 0.210017506281863e-16, 0.705106224399834e21,
    -0.266713136106469e31, -0.145370512554562e-7, 0.149333917053130e28, -0.149795620287641e8,
    -0.381881906271100e16, 0.724660165585797e-4, -0.937808169550193e14, 0.514411468376383e10,
    -0.828198594040141e5 };
            int[] I = { 0, 0, 0, 0, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 8, 8, 10, 12 };
            int[] J = { -3, 1, 5, 8, 8, -4, -1, 4, 5, -8, 4, 8, -6, 6, -2, 1, -8, -2, -5, -8 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int i = 0;
            for (i = 0; i < 20; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;//3y
        }
        double EnRegion_3z_ParaCalcularV3(double pp, double tt)
        {
            double vStar = 0.0038, pStar = 22.0, tStar = 650.0, a = 0.993, b = 0.994;
            int c = 1, d = 1, e = 4;
            double[] no = { 0.244007892290650e-10, -0.463057430331242e7, 0.728803274777712e10,
    0.327776302858856e16, -0.110598170118409e10, -0.323899915729957e13, 0.923814007023245e16,
    0.842250080413712e-12, 0.663221436245506e12, -0.167170186672139e15, 0.253749358701391e4,
    -0.819731559610523e-20, 0.328380587890663e12, -0.625004791171543e8, 0.803197957462023e21,
    -0.204397011338353e-10, -0.378391047055938e4, 0.972876545938620e-2, 0.154355721681459e2,
    -0.373962862928643e4, -0.682859011374572e11, -0.248488015614543e-3, 0.394536049497068e7 };
            int[] I = { -8, -6, -5, -5, -4, -4, -4, -3, -3, -3, -2, -1, 0, 1, 2, 3, 3, 6, 6, 6, 6, 8, 8 };
            int[] J = { 3, 6, 6, 8, 5, 6, 8, -2, 5, 6, 2, -6, 3, 1, 6, -6, -2, -6, -5, -4, -1, -8, -4 };
            double p1 = pp / pStar, teta = tt / tStar, suma = 0.0, omega = 0.0, V3 = 0.0;
            double dpa = p1 - a;
            double dpt = teta - b;
            int i = 0;
            for (i = 0; i < 38; i++)
                suma += no[i] * Math.Pow(dpa, I[i]) * Math.Pow(dpt, J[i]);
            omega = suma * suma * suma * suma;
            V3 = omega * vStar;
            return V3;
        }
        /*
        1 0 0 0.639 767 553 612 785             6 12 14 − 0.378 829 107 169 011 × 1018
        2 1 1 − 0.129 727 445 396 014 × 102     7 16 36 − 0.955 586 736 431 328 × 1035
        3 1 32 − 0.224 595 125 848 403 × 1016   8 24 10 0.187 269 814 676 188 × 1024
        4 4 7 0.177 466 741 801 846 × 107       9 28 0 0.119 254 746 466 473 × 1012
        5 12 4 0.717 079 349 571 538 × 1010     10 32 18 0.110 649 277 244 882 × 1037
        */

        double CalcularPSat3DeEntropia(double ss)
        {
            double pSat = 0.0, sStar = 5.2, pStar = 22.0, nu = 0.0, sum = 0.0;
            double[] nn = { 0.639767553612785, -0.129727445396014e2, -0.224595125848403e16, 0.177466741801846e7, 0.717079349571538e10,
    -0.378829107169011e18,  -0.955586736431328e35, 0.187269814676188e24, 0.119254746466473e12, 0.110649277244882e37 };
            int[] I = { 0, 1, 1, 4, 12, 12, 16, 24, 28, 32 };
            int[] J = { 0, 1, 32, 7, 4, 14, 36, 10, 0, 18 };
            nu = ss / sStar;
            for (int i = 0; i < 10; i++)
                sum += nn[i] * Math.Pow(nu - 1.03, I[i]) * Math.Pow(nu - 0.699, J[i]);
            pSat = sum * pStar;
            return pSat;
        }


        public void CalcularPropiedades(double pp, double TT)
        {
            pp /= 10.0;
            int iRegion;
            double rho = 0.0, t3 = 0.0, v3 = 0.0, Tph = 0.0, Vph = 0.0;
            iRegion = DeterminarRegion(pp, TT);
            switch (iRegion)
            {

                case 1:
                    CalcularRegion1(pp, TT);
                    break;
                case 2:
                    CalcularRegion2(pp, TT);
                    break;
                case 3:
                    //Tph = CalcularT3ph(pp, hh);
                    //Vph = CalcularV3ph(pp, hh);
                    densidadMasica = 1.0 / Vph;
                    volumenEspecificoMasico = Vph;
                    CalcularRegion3(densidadMasica, Tph);
                    break;
                case 5:
                    CalcularRegion5(pp, TT);
                    break;
            }
            volumenEspecificoMolar = volumenEspecificoMasico * WM;
            entalpiaMolar = entalpiaMasica * WM;
            energiaInternaMolar = energiaInternaMasica * WM;
            entropiaMolar = entropiaMasica * WM;
            CpMolar = CpMasico * WM;
            CvMolar = CvMasico * WM;
            densidadMasica = volumenEspecificoMasico == 0 ? 0 : 1.0 / volumenEspecificoMasico;
            densidadMolar = densidadMasica * WM;
            viscosidad = ViscosidadDinamicaDeDensidad(pp, TT, densidadMasica);
            conductividadTermica = thermalConductivity(densidadMasica, TT);
            tensionSuperficial = SurfaceTension(TT);
            viscosidadCinematica = densidadMasica == 0 ? 0: viscosidad / densidadMasica;
        }
        public override void CalculateProperties()
        {
            double presion = Pressure.GetValue(PressureUnits.Bar);
            double temperatura = Temperature.GetValue(TemperatureUnits.Kelvin);
            CalcularPropiedades(presion, temperatura);
            Density.SetValue(densidadMasica, MassDensityUnits.Kg_m3);
            SpecificEnthalpy.SetValue(entalpiaMasica, MassEnergyUnits.KJ_Kg);
            SpecificEntropy.SetValue(entropiaMasica, MassEntropyUnits.KJ_Kg_C);
            SpecificCp.SetValue(CpMasico, MassEntropyUnits.KJ_Kg_C);
            Viscosity.SetValue(viscosidad, ViscosityUnits.Pa_s);

            ThermalConductivity.SetValue(conductividadTermica, ThermalConductivityUnits.W_m_K);
        }

        public override void CalculateVolumetricFlow()
        {
            double result = 0;
            if (Density.GetValue(MassDensityUnits.Kg_m3) != 0)
                result = MassFlow.GetValue(MassFlowUnits.Kg_hr) / Density.GetValue(MassDensityUnits.Kg_m3);
            VolumetricFlow.SetValue(result, VolumetricFlowUnits.m3_hr);
            CalculateEnthalpyFlow();
        }

        public override void CalculateMassFlow()
        {
            var result = VolumetricFlow.GetValue(VolumetricFlowUnits.m3_hr) * Density.GetValue(MassDensityUnits.Kg_m3);
            MassFlow.SetValue(result, MassFlowUnits.Kg_hr);
            CalculateEnthalpyFlow();
        }

        public override void CalculateEnthalpyFlow()
        {
            var result = MassFlow.GetValue(MassFlowUnits.Kg_hr) * SpecificEnthalpy.GetValue(MassEnergyUnits.Kcal_Kg);
            EnthalpyFlow.SetValue(result, EnergyFlowUnits.Kcal_hr);


        }


    }
}