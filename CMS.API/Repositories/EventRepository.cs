﻿using CMS.API.Contracts;
using CMS.API.Entities;
using CMS.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHost;

        public EventRepository(DataContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<int> UpdateEvent(Event eventEntity)
        {
            var existingEntity = await _context.Events.FindAsync(eventEntity.Id);

            if (existingEntity == null)
                return 0; 

            _context.Entry(existingEntity).CurrentValues.SetValues(eventEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEvent(int id)
        {
            var existingEntity = await _context.Events.FindAsync(id);

            if (existingEntity == null)
                return 0; 

            _context.Events.Remove(existingEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateEvent(Event eventEntity)
        {
            try
            {
                string folder = Path.Combine(_webHost.WebRootPath, "public");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string originalFileName = Path.GetFileNameWithoutExtension(eventEntity.Image.FileName);
                string fileExtension = Path.GetExtension(eventEntity.Image.FileName);
                string uniqueFileName = $"{originalFileName}_{DateTime.Now:yyyyMMddHHmmssfff}{fileExtension}";

                eventEntity.ImageName = uniqueFileName;

                eventEntity.Id = 0;

                _context.Events.Add(eventEntity);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbEx)
                {
                    Console.WriteLine($"Database update error: {dbEx.Message}");

                    if (dbEx.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {dbEx.InnerException.Message}");
                    }

                    return 0;
                }

                string filepath = Path.Combine(folder, uniqueFileName);

                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await eventEntity.Image.CopyToAsync(fileStream);
                }

                Console.WriteLine("Uploaded");
                return eventEntity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0; 
            }
        }

    }
}
