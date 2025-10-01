using Atividade_Empresa.DataContexts;
using Atividade_Empresa.Models;
using Atividade_Empresa.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Atividade_Empresa.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? razaoSocial,
            [FromQuery] string? nomeFantasia,
            [FromQuery] string? cnpj
            )
        {
            var query = _context.Empresas.AsQueryable();
            if(razaoSocial is not null)
            {
                query = query.Where(x => x.Razao_social.Contains(razaoSocial));
            }
            if(nomeFantasia is not null)
            {
                query = query.Where(x => x.Nome_fantasia.Equals(nomeFantasia));
            };
            if (cnpj is not null)
            {
                query = query.Where(x => x.CNPJ.Equals(cnpj));
            };

            var empresas = await query.Select(x => new
            {
                x.Razao_social,
                x.Nome_fantasia,
                x.CNPJ,
                x.Telefone,
                x.Email
                ,
            }).ToListAsync();

            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);
            return Ok(empresa);
        }

        [HttpPost("/api/empresa/cadastro")]
        public async Task<IActionResult> Criar([FromBody] Empresa novaEmpresa)
        {
            var empresa = new Empresa()
            {
               Razao_social = novaEmpresa.Razao_social,
               Nome_fantasia = novaEmpresa.Nome_fantasia,
               CNPJ = novaEmpresa.CNPJ,
               Insc_estadual = novaEmpresa.Insc_estadual,
               Telefone = novaEmpresa.Telefone,
               Email = novaEmpresa.Email,
               Cidade = novaEmpresa.Cidade,
               UF = novaEmpresa.UF,
               CEP = novaEmpresa.CEP
            };

            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();

            return Created("",empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] EmpresaDTO atualizarEmpresa)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);

            if(empresa is null)
            {
                return NotFound();
            }

            empresa.Razao_social = atualizarEmpresa.Razao_social;
            empresa.Nome_fantasia = atualizarEmpresa.Nome_fantasia;
            empresa.Telefone = atualizarEmpresa.Telefone;
            empresa.Email = atualizarEmpresa.Email;
            empresa.Cidade = atualizarEmpresa.Cidade;
            empresa.UF = atualizarEmpresa.UF;
            empresa.CEP = atualizarEmpresa.CEP;

            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();

            return Ok(empresa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);

            if(empresa is null)
                {
                    return NotFound();
                }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return Ok(empresa);
        }
    }
}
