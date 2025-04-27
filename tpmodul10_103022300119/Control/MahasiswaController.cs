using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300119.Models;

namespace tpmodul10_103022300119.Control
{
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Nama Kamu", Nim = "1302000001" },
            new Mahasiswa { Nama = "Stephen Curry", Nim = "1302000002" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return mahasiswaList;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();
            return mahasiswaList[index];
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return Ok();
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(index);
            return Ok();
        }
    }
}
