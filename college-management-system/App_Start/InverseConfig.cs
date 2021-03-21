using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Repositories;

namespace CollegeManagementSystem
{
    public class InverseConfig
    {
        private static IContainer Container { get; set; }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("Repository"))
                .As(t => t.GetInterfaces().Single(i => i.Name.EndsWith(t.Name)));

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("Service"))
                .As(t => t.GetInterfaces().Single(i => i.Name.EndsWith(t.Name)));

            builder.RegisterType<CollegeContext>().InstancePerRequest();

            builder.RegisterType<HomeController>();
            builder.RegisterType<StudentController>();
            builder.RegisterType<TeacherController>();
            builder.RegisterType<CourseController>();
            builder.RegisterType<SubjectController>();
            builder.RegisterType<EnrollmentController>();
            builder.RegisterType<GradeController>();

            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}