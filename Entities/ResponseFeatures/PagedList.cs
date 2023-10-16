namespace Entities.ResponseFeatures {

	public class PagedList<T> {

		public PaginationMetadata Metadata { get; set; }

		public List<T> Items { get; private set; }

		public PagedList(List<T> items, PaginationMetadata metadata) { 
			
			Metadata = metadata;

			Items = items;
		}

		public static PagedList<T> ToPagedList(IEnumerable<T> source, PaginationMetadata metadata) =>
			new PagedList<T>(source.ToList(), metadata);
	}
}
