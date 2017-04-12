using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Reflection; 
using System.Text; 
using System.Threading.Tasks; 
using FluentNHibernate; 
using FluentNHibernate.Automapping; 
using FluentNHibernate.Cfg; 
using FluentNHibernate.Cfg.Db; 
using FluentNHibernate.Conventions.Helpers; 
using NHibernate; 
using NHibernate.Cfg; 
using Spring.Data.NHibernate; 
using WMS.Dao.Mapping; 
using WMS.Model.Domain; 

namespace WMS.Dao.Config 
{	
	class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject 
	{ 
		/// <summary> 
		/// Sets the assemblies to load that contain fluent NHibernate mappings. 
		/// </summary> 
		/// <value>The mapping assemblies. </value> 
		public string[] FluentNhibernateMappingAssemblies { get; set; } 

		/// <summary> 
		///This method will be called after the configuration is processed 
		/// but before the session factory is created. 
		/// Adding the assembly mappings for the 
		/// Fluent NHibernate mapping assemblies to the config object. 
		/// This is done so that later when the session factory is created 
		/// Using the updated configuration it will have 
		/// Fluent NHibernate mappings registered in it. 
		/// </summary> 
		/// <param name=-config-> 
		/// The configuration object that holds the NHibernate configuration. 
		/// </param> 

		protected override void PostProcessConfiguration(Configuration config) 
		{ 
			base.PostProcessConfiguration(config); 
			if (FluentNhibernateMappingAssemblies == null) 
				return; 
			foreach (string assemblyName in FluentNhibernateMappingAssemblies) 
				// Loading the assembly by name and 
				// then adding it as the Mapping assembly. 
				config.AddMappingsFromAssembly(Assembly.Load(assemblyName)); 
				FluentConfiguration fluentConfig = Fluently.Configure(config); 
				Array.ForEach(FluentNhibernateMappingAssemblies, 
						assembly => fluentConfig.Mappings( m => m.AutoMappings.Add(AutoMap.AssemblyOf<Location>()
						.Where(t => t.Namespace == typeof(Location).Namespace) 
						.UseOverridesFromAssemblyOf<LocationMappingOverride>())
				//.Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()) 
				)); 
			fluentConfig.BuildSessionFactory(); 
		} 
	} 
} 