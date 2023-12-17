using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Repositories;
using aspnet.Models;
using aspnet.dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace aspnet.Controllers
{
    // The SneakerController is responsible for handling HTTP requests related to sneakers.
    [ApiController]
    [Route("api/shoe")]
    public class SneakerController : ControllerBase
    {
        // Repository for interacting with sneaker data
        private readonly IRepo _repo;

        // AutoMapper for mapping between different DTOs and models
        private readonly IMapper _map;

        // Constructor for SneakerController
        public SneakerController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        // HTTP GET endpoint to retrieve all sneakers
        [HttpGet]
        public ActionResult GetAllSneakers()
        {
            // Return a 200 OK response with the mapped IEnumerable<SneakerReadDto> result
            return Ok(_map.Map<IEnumerable<SneakerReadDto>>(_repo.GetAllSneakers()));
        }

        // HTTP GET endpoint to retrieve a specific sneaker by ID
        [HttpGet("{id}", Name = "GetSneakerById")]
        public ActionResult GetSneakerById(int id)
        {
            // Return a 200 OK response with the mapped SneakerReadDto result
            return Ok(_map.Map<SneakerReadDto>(_repo.GetSneakerById(id)));
        }

        // HTTP POST endpoint to add a new sneaker
        [HttpPost]
        public ActionResult AddSneaker(SneakerWriteDto t)
        {
            // Map SneakerWriteDto to Sneaker
            var sneaker = _map.Map<Sneaker>(t);

            // Add the new sneaker to the repository
            _repo.AddSneaker(sneaker);
            _repo.SaveChanges();

            // Return a 201 Created response with the newly created sneaker
            return CreatedAtRoute(nameof(GetSneakerById), new { Id = sneaker.Id }, sneaker);
        }

        // HTTP PUT endpoint to update an existing sneaker
        [HttpPut("{id}")]
        public ActionResult UpdateSneaker(int id, SneakerUpdateDto t)
        {
            // Retrieve the existing sneaker by ID
            var existingSneaker = _repo.GetSneakerById(id);

            // If the sneaker does not exist, return a 404 Not Found response
            if (existingSneaker == null)
            {
                return NotFound();
            }

            // Map properties from SneakerUpdateDto to the existing sneaker
            _map.Map(t, existingSneaker);

            // Update the sneaker in the repository
            _repo.UpdateSneaker(existingSneaker);

            // Save changes to the repository
            _repo.SaveChanges();

            // Return a 200 OK response
            return Ok();
        }

        // HTTP DELETE endpoint to delete an existing sneaker by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteSneaker(int id)
        {
            // Retrieve the existing sneaker by ID
            var existingSneaker = _repo.GetSneakerById(id);

            // If the sneaker does not exist, return a 404 Not Found response
            if (existingSneaker == null)
            {
                return NotFound();
            }

            // Delete the sneaker from the repository
            _repo.DeleteSneaker(existingSneaker);

            // Save changes to the repository
            _repo.SaveChanges();

            // Return a 200 OK response
            return Ok();
        }
    }
}
