using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300119.Models;
using System.Collections.Generic;
using tpmodul10_103022300119.Models;

namespace tpmodul10_103022300119.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Riziq Rizwan", Nim = "103022300119" },
            new Mahasiswa { Nama = "Frizam Dafa Maulana", Nim = "103022300011" },
            new Mahasiswa { Nama = "Naufal Muhammad Dzulfikar", Nim = "103022300021" },
            new Mahasiswa { Nama = "Bagas Pratama", Nim = "103022300035" },
            new Mahasiswa { Nama = "Raffa Rizky Febryan", Nim = "103022330138" }
         
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
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
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new {index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
