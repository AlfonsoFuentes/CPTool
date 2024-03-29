﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CPTool.ApplicationCQRS.Contracts;
using DocumentFormat.OpenXml.Vml.Office;
using CPTool.Domain.Common;

namespace CPToolCQRS.Infrastructure.Persistence
{
    public class TableContext : DbContext
    {
        //private readonly ILoggedInUserService? _loggedInUserService;
        public TableContext(DbContextOptions<TableContext> options)
            : base(options)
        {


        }
        //public TableContext(DbContextOptions<TableContext> options, ILoggedInUserService loggedInUserService)
        //   : base(options)
        //{
        //    _loggedInUserService = loggedInUserService;
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<MWOType>().HasMany(c => c.MWOs).WithOne(t => t.MWOType).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.MWOItems).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.UserRequirements).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.Signals).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.ControlLoops).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasMany(c => c.PurchaseOrders).WithOne(t => t.MWO).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWO>().HasOne(c => c.ProjectLeader).WithMany(t => t.MWOs).OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Chapter>().HasMany(c => c.MWOItems).WithOne(t => t.Chapter).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.UnitaryBasePrize).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().HasMany(c => c.PurchaseOrderItems).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.Signals).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.Taks).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<MWOItem>().HasOne(c => c.EquipmentType).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.EquipmentTypeSub).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.ProcessCondition).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.ProcessFluid).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.InnerMaterial).WithMany(t => t.MWOItemInnerMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.MaterialOuter).WithMany(t => t.MWOItemOuterMaterials).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.Brand).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.Supplier).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.Nozzles).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MWOItem>().HasMany(c => c.PropertySpecifications).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MWOItem>().HasMany(c => c.PipeAccesorys).WithOne(t => t.MWOItem).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.MeasuredVariable).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.MeasuredVariableModifier).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.DeviceFunction).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.DeviceFunctionModifier).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.Readout).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().HasOne(c => c.NozzleStart).WithMany(t => t.StartMWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.NozzleFinish).WithMany(t => t.FinishMWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.StartMWOItem).WithMany(t => t.StartMWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.FinishMWOItem).WithMany(t => t.FinishMWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().HasOne(c => c.Diameter).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MWOItem>().HasOne(c => c.PipeClass).WithMany(t => t.MWOItems).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MWOItem>().Navigation(e => e.MaterialOuter).AutoInclude();
            modelBuilder.Entity<MWOItem>().Navigation(e => e.InnerMaterial).AutoInclude();
            modelBuilder.Entity<PipeClass>().HasMany(c => c.PipeDiameters).WithOne(t => t.dPipeClass).OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.OuterDiameter).WithMany(t => t.ODs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.InternalDiameter).WithMany(t => t.IDs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeDiameter>().HasOne(c => c.Thickness).WithMany(t => t.Thicknesss).OnDelete(DeleteBehavior.NoAction);

           

            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pBrand).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasOne(c => c.pSupplier).WithMany(t => t.PurchaseOrders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasMany(c => c.PurchaseOrderItems).WithOne(t => t.PurchaseOrder).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.pBrand).AutoInclude();
            modelBuilder.Entity<PurchaseOrder>().Navigation(e => e.pSupplier).AutoInclude();
          
           
            
            modelBuilder.Entity<PurchaseOrderItem>().HasOne(c => c.MWOItem).WithMany(t => t.PurchaseOrderItems).OnDelete(DeleteBehavior.NoAction);
       

            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Pressure).WithMany(t => t.Pressures).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Temperature).WithMany(t => t.Temperatures).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.MassFlow).WithMany(t => t.MassFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.VolumetricFlow).WithMany(t => t.VolumetricFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Density).WithMany(t => t.Densitys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.Viscosity).WithMany(t => t.Viscositys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.EnthalpyFlow).WithMany(t => t.EnthalpyFlows).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.SpecificEnthalpy).WithMany(t => t.SpecificEnthalpys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.ThermalConductivity).WithMany(t => t.ThermalConductivitys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessCondition>().HasOne(c => c.SpecificCp).WithMany(t => t.SpecificCps).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Pressure).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Temperature).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.MassFlow).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.VolumetricFlow).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Density).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.Viscosity).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.EnthalpyFlow).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.SpecificEnthalpy).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.ThermalConductivity).AutoInclude();
            modelBuilder.Entity<ProcessCondition>().Navigation(e => e.SpecificCp).AutoInclude();


            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Friction).WithMany(t => t.FrictionPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.Reynold).WithMany(t => t.ReynoldPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelInlet).WithMany(t => t.LevelInletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.LevelOutlet).WithMany(t => t.LevelOutletPipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.FrictionDropPressure).WithMany(t => t.FrictionDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.OverallDropPressure).WithMany(t => t.OverallDropPressurePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.ElevationChange).WithMany(t => t.ElevationChangePipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.pProcessCondition).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paProcessFluid).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasMany(c => c.Nozzles).WithOne(t => t.PipeAccesory).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paDiameter).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paPipeClass).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PipeAccesory>().HasOne(c => c.paMaterial).WithMany(t => t.PipeAccesorys).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLD).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Supplier>().HasOne(c => c.TaxCodeLP).WithMany(t => t.Suppliers).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLD).AutoInclude();
            modelBuilder.Entity<Supplier>().Navigation(e => e.TaxCodeLP).AutoInclude();



            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectionType).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nGasket).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nMaterial).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.PipeDiameter).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.nPipeClass).WithMany(t => t.Nozzles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().HasOne(c => c.ConnectedTo).WithMany(t => t.NozzlesConnecteds).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Nozzle>().Navigation(e => e.ConnectionType).AutoInclude();
            modelBuilder.Entity<Nozzle>().Navigation(e => e.nGasket).AutoInclude();
            modelBuilder.Entity<Nozzle>().Navigation(e => e.nMaterial).AutoInclude();
            modelBuilder.Entity<Nozzle>().Navigation(e => e.PipeDiameter).AutoInclude();
            modelBuilder.Entity<Nozzle>().Navigation(e => e.nPipeClass).AutoInclude();
    

            modelBuilder.Entity<ProcessFluid>().HasOne(c => c.PropertyPackage).WithMany(t => t.ProcessFluids).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProcessFluid>().Navigation(e => e.PropertyPackage).AutoInclude();

            modelBuilder.Entity<DownPayment>().HasOne(c => c.PurchaseOrder).WithMany(t => t.DownPayments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DownPayment>().Navigation(e => e.PurchaseOrder).AutoInclude();

            modelBuilder.Entity<Taks>().HasOne(c => c.MWO).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.MWOItem).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.PurchaseOrder).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Taks>().HasOne(c => c.DownPayment).WithMany(t => t.Taks).OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<UserRequirement>().HasOne(c => c.UserRequirementType).WithMany(t => t.UserRequirements).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRequirement>().HasOne(c => c.RequestedBy).WithMany(t => t.UserRequirements).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BrandSupplier>()
             .HasKey(t => new { t.BrandId, t.SupplierId });

            modelBuilder.Entity<BrandSupplier>()
                .HasOne(pt => pt.Brand)
                .WithMany(p => p.BrandSuppliers)
                .HasForeignKey(pt => pt.BrandId);

            modelBuilder.Entity<BrandSupplier>()
                .HasOne(pt => pt.Supplier)
                .WithMany(t => t.BrandSuppliers)
                .HasForeignKey(pt => pt.SupplierId);
            modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Brand).AutoInclude();
            modelBuilder.Entity<BrandSupplier>().Navigation(e => e.Supplier).AutoInclude();

            modelBuilder.Entity<Signal>().HasOne(c => c.SignalType).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.Wire).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.FieldLocation).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.ElectricalBox).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Signal>().HasOne(c => c.SignalModifier).WithMany(t => t.Signals).OnDelete(DeleteBehavior.NoAction);
           


            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ControlledVariable).WithMany(t => t.ControlledVariables).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariable).WithMany(t => t.ProcessVariables).OnDelete(DeleteBehavior.NoAction);
       

            modelBuilder.Entity<ControlLoop>().HasOne(c => c.SP).WithMany(t => t.SPs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableMin).WithMany(t => t.ProcessVariableMins).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableMax).WithMany(t => t.ProcessVariableMaxs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ProcessVariableValue).WithMany(t => t.ProcessVariableValues).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ControlLoop>().HasOne(c => c.ControlledVariable).WithMany(t => t.ControlledVariables).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Specification>().HasOne(c => c.EquipmentType).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.EquipmentTypeSub).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.DeviceFunction).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.DeviceFunctionModifier).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.MeasuredVariable).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.MeasuredVariableModifier).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Specification>().HasOne(c => c.Readout).WithMany(t => t.Specifications).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Specification>().HasMany(c => c.PropertySpecifications).WithOne(t => t.Specification).OnDelete(DeleteBehavior.Cascade);


        }




        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<MWOType>? MWOTypes { get; set; }
        public DbSet<MWO>? MWOs { get; set; }
        public DbSet<MWOItem>? MWOItems { get; set; }
        public DbSet<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }


        public DbSet<Specification>? Specifications { get; set; }
        public DbSet<PropertySpecification>? PropertySpecifications { get; set; }
        public DbSet<UnitaryBasePrize>? UnitaryBasePrizes { get; set; }
        public DbSet<Gasket>? Gaskets { get; set; }
        public DbSet<EquipmentType>? EquipmentTypes { get; set; }
        public DbSet<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }

        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<BrandSupplier>? BrandSuppliers { get; set; }
        public DbSet<Material>? Materials { get; set; }
        public DbSet<TaxCodeLD>? TaxCodeLDs { get; set; }

        public DbSet<TaxCodeLP>? TaxCodeLPs { get; set; }

        public DbSet<DownPayment>? DownPayments { get; set; }

        public DbSet<MeasuredVariable>? MeasuredVariables { get; set; }
        public DbSet<MeasuredVariableModifier>? MeasuredVariableModifiers { get; set; }
        public DbSet<DeviceFunction>? DeviceFunctions { get; set; }
        public DbSet<DeviceFunctionModifier>? DeviceFunctionModifiers { get; set; }
        public DbSet<Readout>? Readouts { get; set; }
        public DbSet<EntityUnit>? Units { get; set; }
        public DbSet<ProcessFluid>? ProcessFluids { get; set; }
        public DbSet<PipeDiameter>? PipeDiameters { get; set; }
        public DbSet<Nozzle>? Nozzles { get; set; }
        public DbSet<PipeAccesory>? PipeAccesorys { get; set; }
        public DbSet<PipeClass>? PipeClasss { get; set; }
        public DbSet<ConnectionType>? ConnectionTypes { get; set; }
        public DbSet<ProcessCondition>? ProcessConditions { get; set; }
        public DbSet<PropertyPackage>? PropertyPackages { get; set; }
        public DbSet<Taks>? Takss { get; set; }
        public DbSet<UserRequirementType>? UserRequirementTypes { get; set; }
        public DbSet<UserRequirement>? UserRequirements { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<SignalType>? SignalTypes { get; set; }
        public DbSet<Wire>? Wires { get; set; }
        public DbSet<FieldLocation>? FieldLocations { get; set; }
        public DbSet<ElectricalBox>? ElectricalBoxs { get; set; }
        public DbSet<Signal>? Signals { get; set; }
        public DbSet<SignalModifier>? SignalModifiers { get; set; }
        public DbSet<ControlLoop>? ControlLoops { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entittes = ChangeTracker.Entries<AuditableEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            foreach (var entry in entittes)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "system";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        entry.Entity.UpdateBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateBy = "system";
                        entry.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                }
            }
            var retorno = await base.SaveChangesAsync(cancellationToken);

            return retorno;
        }
    }
}
