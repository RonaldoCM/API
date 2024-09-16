using APITaskManager.Services.Tarefas;
using Autofac;

namespace APITaskManager.IoC
{
    public static class IoCTarefas
    {

        public static void AddDependencies(ContainerBuilder cb, bool fake)
        {
            if (fake)
            {
                cb.RegisterType<FakeTarefasService>().As<ITarefaService>().InstancePerRequest();
            }
            else
            {
                cb.RegisterType<TarefasService>().As<ITarefaService>().InstancePerRequest();
            }
        }
    }
}
