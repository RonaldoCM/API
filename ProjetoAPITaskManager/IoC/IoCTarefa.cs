using APITaskManager.Services.Tarefas.Implements;
using APITaskManager.Services.Tarefas.Model;
using Autofac;

namespace APITaskManager.IoC
{
    public static class IoCTarefa
    {

        public static void AddDependencies(ContainerBuilder cb, bool fake)
        {
            if (fake)
            {
                cb.RegisterType<FakeTarefaService>().As<ITarefaService>().InstancePerRequest();
            }
            else
            {
                cb.RegisterType<TarefaService>().As<ITarefaService>().InstancePerRequest();
            }
        }
    }
}
