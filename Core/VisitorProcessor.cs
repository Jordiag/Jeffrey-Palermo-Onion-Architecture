namespace Core
{
    public class VisitorProcessor
    {
        private readonly IVisitorBuilder _builder;
        private readonly IVisitorRepository _repository;

        public VisitorProcessor(IVisitorBuilder builder, IVisitorRepository repository)
        {
            _builder = builder;
            _repository = repository;
        }

        public void Process()
        {
            Visitor visitor = _builder.BuildVisitor();
            _repository.Save(visitor);
        }
    }
}