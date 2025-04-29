using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
    public class DocumentToReturnDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl{ get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }
        public bool IsActive { get; set; }
        public string Version { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalHistoryId { get; set; }
        public string DownloadLink { get; set; }
    }
}
