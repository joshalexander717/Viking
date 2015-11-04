﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConnectomeDataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ConnectomeEntities : DbContext
    {
        public ConnectomeEntities()
            : base("name=ConnectomeEntities")
        {
        }
    
    	public ConnectomeEntities(string connection_string)
            : base(connection_string)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeletedLocation> DeletedLocations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationLink> LocationLinks { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<StructureType> StructureTypes { get; set; }
        public virtual DbSet<StructureLink> StructureLinks { get; set; }
    
        public virtual ObjectResult<ApproximateStructureLocation_Result> ApproximateStructureLocation(Nullable<int> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApproximateStructureLocation_Result>("ApproximateStructureLocation", structureIDParameter);
        }
    
        public virtual ObjectResult<CountChildStructuresByType_Result> CountChildStructuresByType(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CountChildStructuresByType_Result>("CountChildStructuresByType", structureIDParameter);
        }
    
        public virtual int MergeStructures(Nullable<long> keepStructureID, Nullable<long> mergeStructureID)
        {
            var keepStructureIDParameter = keepStructureID.HasValue ?
                new ObjectParameter("KeepStructureID", keepStructureID) :
                new ObjectParameter("KeepStructureID", typeof(long));
    
            var mergeStructureIDParameter = mergeStructureID.HasValue ?
                new ObjectParameter("MergeStructureID", mergeStructureID) :
                new ObjectParameter("MergeStructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MergeStructures", keepStructureIDParameter, mergeStructureIDParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectAllStructureLocationLinks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectAllStructureLocationLinks");
        }
    
        public virtual ObjectResult<LocationLink> SelectAllStructureLocationLinks(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectAllStructureLocationLinks", mergeOption);
        }
    
        public virtual ObjectResult<Location> SelectAllStructureLocations()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectAllStructureLocations");
        }
    
        public virtual ObjectResult<Location> SelectAllStructureLocations(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectAllStructureLocations", mergeOption);
        }
    
        public virtual ObjectResult<Structure> SelectAllStructures()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectAllStructures");
        }
    
        public virtual ObjectResult<Structure> SelectAllStructures(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectAllStructures", mergeOption);
        }
    
        public virtual ObjectResult<StructureLink> SelectChildrenStructureLinks(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StructureLink>("SelectChildrenStructureLinks", structureIDParameter);
        }
    
        public virtual ObjectResult<StructureLink> SelectChildrenStructureLinks(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StructureLink>("SelectChildrenStructureLinks", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<Location> SelectLastModifiedLocationByUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectLastModifiedLocationByUsers");
        }
    
        public virtual ObjectResult<Location> SelectLastModifiedLocationByUsers(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectLastModifiedLocationByUsers", mergeOption);
        }
    
        public virtual ObjectResult<SelectNumConnectionsPerStructure_Result> SelectNumConnectionsPerStructure()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectNumConnectionsPerStructure_Result>("SelectNumConnectionsPerStructure");
        }
    
        public virtual ObjectResult<Structure> SelectRootStructures()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectRootStructures");
        }
    
        public virtual ObjectResult<Structure> SelectRootStructures(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectRootStructures", mergeOption);
        }
    
        public virtual ObjectResult<LocationLink> SelectSectionLocationLinks(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectSectionLocationLinks", zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectSectionLocationLinks(Nullable<double> z, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectSectionLocationLinks", mergeOption, zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Location> SelectSectionLocationsAndLinks(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectSectionLocationsAndLinks", zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Location> SelectSectionLocationsAndLinks(Nullable<double> z, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectSectionLocationsAndLinks", mergeOption, zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectStructure(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructure", structureIDParameter);
        }
    
        public virtual ObjectResult<Structure> SelectStructure(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructure", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<SelectStructureChangeLog_Result> SelectStructureChangeLog(Nullable<long> structure_ID, Nullable<System.DateTime> begin_time, Nullable<System.DateTime> end_time)
        {
            var structure_IDParameter = structure_ID.HasValue ?
                new ObjectParameter("structure_ID", structure_ID) :
                new ObjectParameter("structure_ID", typeof(long));
    
            var begin_timeParameter = begin_time.HasValue ?
                new ObjectParameter("begin_time", begin_time) :
                new ObjectParameter("begin_time", typeof(System.DateTime));
    
            var end_timeParameter = end_time.HasValue ?
                new ObjectParameter("end_time", end_time) :
                new ObjectParameter("end_time", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStructureChangeLog_Result>("SelectStructureChangeLog", structure_IDParameter, begin_timeParameter, end_timeParameter);
        }
    
        public virtual ObjectResult<SelectStructureLabels_Result> SelectStructureLabels()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStructureLabels_Result>("SelectStructureLabels");
        }
    
        public virtual ObjectResult<SelectStructureLocationChangeLog_Result> SelectStructureLocationChangeLog(Nullable<long> structure_ID, Nullable<System.DateTime> begin_time, Nullable<System.DateTime> end_time)
        {
            var structure_IDParameter = structure_ID.HasValue ?
                new ObjectParameter("structure_ID", structure_ID) :
                new ObjectParameter("structure_ID", typeof(long));
    
            var begin_timeParameter = begin_time.HasValue ?
                new ObjectParameter("begin_time", begin_time) :
                new ObjectParameter("begin_time", typeof(System.DateTime));
    
            var end_timeParameter = end_time.HasValue ?
                new ObjectParameter("end_time", end_time) :
                new ObjectParameter("end_time", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectStructureLocationChangeLog_Result>("SelectStructureLocationChangeLog", structure_IDParameter, begin_timeParameter, end_timeParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectStructureLocationLinks(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectStructureLocationLinks", structureIDParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectStructureLocationLinks(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectStructureLocationLinks", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectStructureLocationLinksNoChildren(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectStructureLocationLinksNoChildren", structureIDParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectStructureLocationLinksNoChildren(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectStructureLocationLinksNoChildren", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<Location> SelectStructureLocations(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectStructureLocations", structureIDParameter);
        }
    
        public virtual ObjectResult<Location> SelectStructureLocations(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectStructureLocations", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<Structure> SelectStructuresAndLinks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructuresAndLinks");
        }
    
        public virtual ObjectResult<Structure> SelectStructuresAndLinks(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructuresAndLinks", mergeOption);
        }
    
        public virtual ObjectResult<Structure> SelectStructuresForSection(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructuresForSection", zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectStructuresForSection(Nullable<double> z, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectStructuresForSection", mergeOption, zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> SelectUnfinishedStructureBranches(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("SelectUnfinishedStructureBranches", structureIDParameter);
        }
    
        public virtual ObjectResult<SelectUnfinishedStructureBranchesWithPosition_Result> SelectUnfinishedStructureBranchesWithPosition(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectUnfinishedStructureBranchesWithPosition_Result>("SelectUnfinishedStructureBranchesWithPosition", structureIDParameter);
        }
    
        [DbFunction("ConnectomeEntities", "SectionLocations")]
        public virtual IQueryable<Location> SectionLocations(Nullable<double> z)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Location>("[ConnectomeEntities].[SectionLocations](@Z)", zParameter);
        }
    
        [DbFunction("ConnectomeEntities", "SectionLocationsModifiedAfterDate")]
        public virtual IQueryable<Location> SectionLocationsModifiedAfterDate(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Location>("[ConnectomeEntities].[SectionLocationsModifiedAfterDate](@Z, @QueryDate)", zParameter, queryDateParameter);
        }
    
        [DbFunction("ConnectomeEntities", "SectionLocationLinks")]
        public virtual IQueryable<LocationLink> SectionLocationLinks(Nullable<double> z)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<LocationLink>("[ConnectomeEntities].[SectionLocationLinks](@Z)", zParameter);
        }
    
        [DbFunction("ConnectomeEntities", "SectionLocationLinksModifiedAfterDate")]
        public virtual IQueryable<LocationLink> SectionLocationLinksModifiedAfterDate(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<LocationLink>("[ConnectomeEntities].[SectionLocationLinksModifiedAfterDate](@Z, @QueryDate)", zParameter, queryDateParameter);
        }
    
        [DbFunction("ConnectomeEntities", "StructureLocationLinks")]
        public virtual IQueryable<LocationLink> StructureLocationLinks(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<LocationLink>("[ConnectomeEntities].[StructureLocationLinks](@StructureID)", structureIDParameter);
        }
    
        public virtual ObjectResult<Location> SelectSectionLocationsAndLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> radius, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var radiusParameter = radius.HasValue ?
                new ObjectParameter("Radius", radius) :
                new ObjectParameter("Radius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectSectionLocationsAndLinksInBounds", zParameter, bBoxParameter, radiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Location> SelectSectionLocationsAndLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> radius, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var radiusParameter = radius.HasValue ?
                new ObjectParameter("Radius", radius) :
                new ObjectParameter("Radius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectSectionLocationsAndLinksInBounds", mergeOption, zParameter, bBoxParameter, radiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Location> SelectStructureLocationsAndLinks(Nullable<long> structureID)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectStructureLocationsAndLinks", structureIDParameter);
        }
    
        public virtual ObjectResult<Location> SelectStructureLocationsAndLinks(Nullable<long> structureID, MergeOption mergeOption)
        {
            var structureIDParameter = structureID.HasValue ?
                new ObjectParameter("StructureID", structureID) :
                new ObjectParameter("StructureID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Location>("SelectStructureLocationsAndLinks", mergeOption, structureIDParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> SelectStructuresLinkedViaChildren(Nullable<long> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("SelectStructuresLinkedViaChildren", iDParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructures(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructures", zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructures(Nullable<double> z, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructures", mergeOption, zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresInBounds", zParameter, bBoxParameter, minRadiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresInBounds", mergeOption, zParameter, bBoxParameter, minRadiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresAndLinks(Nullable<double> z, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresAndLinks", zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresAndLinks(Nullable<double> z, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresAndLinks", mergeOption, zParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<ApproximateStructureLocations_Result> ApproximateStructureLocations()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ApproximateStructureLocations_Result>("ApproximateStructureLocations");
        }
    
        public virtual ObjectResult<LocationLink> SelectSectionLocationLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bbox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bboxParameter = bbox != null ?
                new ObjectParameter("bbox", bbox) :
                new ObjectParameter("bbox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectSectionLocationLinksInBounds", zParameter, bboxParameter, minRadiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<LocationLink> SelectSectionLocationLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bbox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bboxParameter = bbox != null ?
                new ObjectParameter("bbox", bbox) :
                new ObjectParameter("bbox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LocationLink>("SelectSectionLocationLinksInBounds", mergeOption, zParameter, bboxParameter, minRadiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresAndLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresAndLinksInBounds", zParameter, bBoxParameter, minRadiusParameter, queryDateParameter);
        }
    
        public virtual ObjectResult<Structure> SelectSectionStructuresAndLinksInBounds(Nullable<double> z, System.Data.Entity.Spatial.DbGeometry bBox, Nullable<double> minRadius, Nullable<System.DateTime> queryDate, MergeOption mergeOption)
        {
            var zParameter = z.HasValue ?
                new ObjectParameter("Z", z) :
                new ObjectParameter("Z", typeof(double));
    
            var bBoxParameter = bBox != null ?
                new ObjectParameter("BBox", bBox) :
                new ObjectParameter("BBox", typeof(System.Data.Entity.Spatial.DbGeometry));
    
            var minRadiusParameter = minRadius.HasValue ?
                new ObjectParameter("MinRadius", minRadius) :
                new ObjectParameter("MinRadius", typeof(double));
    
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Structure>("SelectSectionStructuresAndLinksInBounds", mergeOption, zParameter, bBoxParameter, minRadiusParameter, queryDateParameter);
        }
    }
}
