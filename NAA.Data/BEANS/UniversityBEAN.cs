using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.BEANS
{
    public class UniversityBEAN
    {
        public UniversityBEAN() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntryReq { get; set; }
        public int University { get; set; }
        public string UniversityName { get; set; }

    }
}

/* FOR SHEFF UNI
<Id>int</Id>                                <CourseId>int</CourseId>
<Name>string</Name>                         <CourseName>string</CourseName>
<Description>string</Description>           <CourseDescription>string</CourseDescription>
<EntryReq>string</EntryReq>                 <EntryCriteria>string</EntryCriteria>
<Tarif>int</Tarif>
<University>string</University>
<NSS>int</NSS>
<Qulaification>string</Qulaification>

 * 
FOR SHEFF HALLAM

          <CourseId>int</CourseId>
          <CourseName>string</CourseName>
          <EntryCriteria>string</EntryCriteria>
          <CourseDescription>string</CourseDescription>
          <CourseContent>string</CourseContent>

*/