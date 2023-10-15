namespace Entities.ResponseFeatures {

	public class PagedList<T> : List<T> {

		public PaginationMetadata Metadata { get; set; }

		public PagedList(List<T> items, PaginationMetadata metadata) { 
			
			Metadata = metadata;

			AddRange(items);
		}

		public static PagedList<T> ToPagedList(IEnumerable<T> source, PaginationMetadata metadata) =>
			new PagedList<T>(source.ToList(), metadata);
	}
}
