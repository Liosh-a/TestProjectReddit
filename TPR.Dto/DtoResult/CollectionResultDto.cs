using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.Dto.DtoResult
{
    public class CollectionResultDto<T> :ResultDto
    {
        public ICollection<T> Data { get; set; }
        public int Count { get; set; }
    }
}
