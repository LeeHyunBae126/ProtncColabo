using LiteDB;
using ProtncColabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtncColabo.Services
{
    // LiteDB를 통해 출퇴근 로그를 저장하고 불러오는 서비스 클래스
    public class LiteDbService
    {
        // 데이터베이스 파일 이름
        private const string DB_FILE = "Attendance.db";

        // 출근/퇴근 로그 1건을 DB에 저장
        public void InsertLog(AttendanceLog log)
        {
            using (var db = new LiteDatabase(DB_FILE))
            {
                var col = db.GetCollection<AttendanceLog>("logs"); // logs 컬렉션 가져오기
                col.Insert(log); // 로그 삽입
            }
        }

        // 모든 로그를 시간 역순으로 조회해서 반환
        public List<AttendanceLog> GetAllLogs()
        {
            using (var db = new LiteDatabase(DB_FILE))
            {
                var col = db.GetCollection<AttendanceLog>("logs"); // logs 컬렉션 가져오기
                return col.Query().OrderByDescending(x => x.ScanTime).ToList(); // 시간 기준 정렬 반환
            }
        }
    }
}
