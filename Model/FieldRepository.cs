using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WFFM8.To.SQL.Model
{
    class FieldRepository
    {
        public IField Get(IForm form, Guid fieldId)
        {
            return form == null ? null : form.Field.FirstOrDefault(field => field.FieldId == fieldId);
        }
    }
}
