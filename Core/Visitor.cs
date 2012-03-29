using System;

namespace Core
{
	public class Visitor
	{
		public Guid Id { get; set; }
		public string PathAndQuerystring { get; set; }
		public string LoginName { get; set; }
		public string Browser { get; set; }
		public DateTime VisitDate { get; set; }
		public string IpAddress { get; set; }
	}
}