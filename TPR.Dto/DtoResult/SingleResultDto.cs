using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.Dto.DtoResult
{
    public class SingleResultDto<T> : ResultDto
    {
        public T Data { get; set; }
    }
}
