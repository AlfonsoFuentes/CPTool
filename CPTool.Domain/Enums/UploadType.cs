using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Enums
{
    public enum UploadType : byte
    {
        [Description(@"Products")]
        Product,
        [Description(@"ProfilePictures")]
        ProfilePicture,
        [Description(@"Documents")]
        Document
    }

}
