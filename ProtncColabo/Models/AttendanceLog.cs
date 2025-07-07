using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace ProtncColabo.Models
{
    // 출퇴근 로그 모델 클래스 (LiteDB의 documents 테이블 역할)
    public class AttendanceLog
    {
        // 기본 키 역할, 자동 증가됨
        [BsonId]
        public int Id { get; set; }

        // 사원 ID (QR 코드로부터 추출됨)
        public string EmployeeId { get; set; }

        // 스캔된 시간 (출근/퇴근 시간)
        public DateTime ScanTime { get; set; }

        // 출근 또는 퇴근 상태
        public string Status { get; set; }
    }
}
