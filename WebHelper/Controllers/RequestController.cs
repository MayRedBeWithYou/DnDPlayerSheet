using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDLibrary.Models;
using DnDPlayerSheet.Models;
using Microsoft.AspNetCore.Mvc;
using WebHelper.EntityFramework;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebHelper.Controllers
{
    [Route("api")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RequestController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("spells")]
        public IEnumerable<Spell> GetSpells([FromQuery] int? id, [FromQuery] Role? role, [FromQuery] int? level, [FromQuery] SpellSchool? school)
        {
            if (id.HasValue) return _context.Spells.Where(x => x.Id == id.Value).AsEnumerable<Spell>();
            IQueryable<Spell> result = _context.Spells;
            if (role.HasValue)
            {
                string r = Conversion.RoleShort(role.Value);
                if (level.HasValue)
                {
                    result = result.Where(x => x.Level.Contains(r + $" {level.Value}"));
                }
                else result = result.Where(x => x.Level.Contains(r));
            }
            else if (level.HasValue) result = result.Where(x => x.Tier == level.Value);
            if (school.HasValue) result = result.Where(x => x.School == school.Value);
            return result.AsEnumerable<Spell>();
        }

        [HttpGet]
        [Route("feats")]
        public IEnumerable<Feat> GetFeats([FromQuery] int? id)
        {
            if (id.HasValue) return _context.Feats.Where(x => x.Id == id.Value).AsEnumerable<Feat>();
            return _context.Feats.AsEnumerable<Feat>();
        }

        [HttpGet]
        [Route("skills")]
        public IEnumerable<Skill> GetSkills()
        {
            return _context.Skills.AsEnumerable<Skill>();
        }

        [HttpGet]
        [Route("combat")]
        public IEnumerable<CombatAction> GetCombatActions([FromQuery] int? id, [FromQuery] string search, [FromQuery] bool? free)
        {
            if (id.HasValue) return _context.CombatActions.Where(x => x.Id == id.Value).AsEnumerable<CombatAction>();
            IQueryable<CombatAction> result = _context.CombatActions;
            if (!String.IsNullOrEmpty(search)) result = result.Where(x => x.Name.Contains(search));
            if (free.HasValue) result = result.Where(x => x.IsFree == free.Value);
            return result.AsEnumerable<CombatAction>();
        }

    }
}
