namespace MVCLearning.UserRepo
{
    public interface IOperation
    {
        Guid GetCurrentId();
    }
    public interface IOperationTransient : IOperation
    {
    }
    public interface IOperationScoped : IOperation
    {
    }
    public interface IOperationSingleton : IOperation
    {
    }
    public interface IOperationSingletonInstance : IOperation
    {
    }

    public class Operation : IOperationScoped, IOperationSingleton, IOperationTransient, IOperationSingletonInstance
    {
        public Guid guid { get; set; }
        public Operation()
        {
            guid = Guid.NewGuid();
        }

        public Operation(Guid guid)
        {
            this.guid = guid;
        }

        public Guid GetCurrentId()
        {
            return guid;
        }
    }

    public class OperationService
    {
        public IOperationTransient _operationTransient { get; }
        public IOperationScoped _operationScoped { get; }
        public IOperationSingleton _operationSingleton { get; }
        public IOperationSingletonInstance _operationSingletonInstance { get; }

        public OperationService(IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationSingletonInstance operationSingletonInstance)
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationSingletonInstance = operationSingletonInstance;
        }
    }
}
