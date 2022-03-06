namespace BLL.QueryObjects
{
    /// <summary>
    /// DTO used for paging during query execution
    /// </summary>
    public struct QueryPagingDTO
    {
        /// <summary>
        /// Index of desired page
        /// </summary>
        public int DesiredPage { get;  }
        
        /// <summary>
        /// Size of one page
        /// </summary>
        public int PageSize { get;  }

        /// <summary>
        /// Constructs paging DTO
        /// </summary>
        /// <param name="desiredPage"> index of page </param>
        /// <param name="pageSize"> size of one page </param>
        public QueryPagingDTO(int desiredPage, int pageSize)
        {
            DesiredPage = desiredPage;
            PageSize = pageSize;
        }
    }
}