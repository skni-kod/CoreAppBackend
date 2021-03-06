using AutoMapper;
using CoreApp.Data;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Services;
public interface ISectionService
{
    public List<ReadSectionDto> GetAll();
    public void PutSection(int id, CreateSectionDto dto);
    public void PatchSection(int id, CreateSectionDto dto);
    public void Delete(int id);
    public ReadSectionDto GetById(int id);
    public int Create(CreateSectionDto dto);
    List<ReadProjectDto> GetAllSections(int id);
}

public class SectionService : ISectionService
{
    private readonly CoreAppDbContext _context;
    private readonly IMapper _mapper;

    public SectionService(CoreAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<ReadSectionDto> GetAll()
    {
        var sections = _context
            .Sections
            .ToList();

        if (sections == null) throw new Exception();

        var result = _mapper.Map<List<ReadSectionDto>>(sections);

        return result;
    }

    public void Delete(int id)
    {
        var section = _context
            .Sections
            .FirstOrDefault(r => r.Id == id);

        if (section == null) throw new Exception();

        _context.Sections.Remove(section);
        _context.SaveChanges();
    }

    public ReadSectionDto GetById(int id)
    {
        var section = _context
            .Sections
            .FirstOrDefault(r => r.Id == id);

        if (section == null) throw new Exception();

        var result = _mapper.Map<ReadSectionDto>(section);

        return result;
    }

    public int Create(CreateSectionDto dto)
    {
        var section = _mapper.Map<Section>(dto);

        _context
            .Sections
            .Add(section);
        _context.SaveChanges();

        return section.Id;
    }

    public List<ReadProjectDto> GetAllSections(int id)
    {
        var section = _context
            .Sections
            .Include(s => s.Projects)
            .FirstOrDefault(s => s.Id == id);

        if(section == null) throw new Exception();

        var projects = section.Projects.ToList();

        var result = _mapper.Map<List<ReadProjectDto>>(projects);

        return result;
    }

    public void PutSection(int id, CreateSectionDto dto)
    {
        var project = _context
            .Projects
            .FirstOrDefault(p => p.Id == id);

        if (project == null) throw new Exception();

        _mapper.Map(dto, project);

        _context.SaveChanges();
    }

    public void PatchSection(int id, CreateSectionDto dto)
    {
        var project = _context
            .Projects
            .FirstOrDefault(p => p.Id == id);

        if (project == null) throw new Exception();

        _mapper.Map(dto, project);

        _context.SaveChanges();
    }
}