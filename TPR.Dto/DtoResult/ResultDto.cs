using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.Dto.DtoResult
{
    public class ResultDto
    {
        public bool IsSuccessful { get; set; }
        public IDictionary<string, string> collectionResult { get; set; }
    }
}
