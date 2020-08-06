namespace cursosNetCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class Pagination<T>: List<T>
    {
        #region Porperties

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalR { get; private set; }

        #endregion

        #region Cosntructors

        public Pagination(List<T> items, int count,int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            TotalR = count;
            this.AddRange(items);

        }

        #endregion

        #region Methods

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, count, pageIndex, pageSize);
        }

        #endregion

    }
}
