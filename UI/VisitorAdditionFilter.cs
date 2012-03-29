using System.Web.Mvc;
using Core;

namespace UI
{
	public class VisitorAdditionFilter : ActionFilterAttribute
	{
	    private readonly VisitorProcessor _processor;

		public VisitorAdditionFilter(VisitorProcessor processor)
		{
		    _processor = processor;
		}

	    public VisitorAdditionFilter()
		{
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
		    VisitorProcessor processor = _processor ??
		                                 new VisitorProcessor(new VisitorBuilder(),
		                                                      new VisitorRepositoryFactory().BuildRepository());
		    
            processor.Process();
		}
	}
}