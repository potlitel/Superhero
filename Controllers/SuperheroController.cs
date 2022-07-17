using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Superhero.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperheroController : ControllerBase
    {
        private static List<SuperheroItem> Superheroes = new List<SuperheroItem> {
            new SuperheroItem { Id= 1,
                                Name="Batman",
                                publisher="DC Comics",
                                alter_ego="Bruce Wayne",
                                first_appearance="Detective Comics #27",
                                characters="Bruce Wayne"
                              },
            new SuperheroItem { Id= 2,
                                Name="Superman",
                                publisher="DC Comics",
                                alter_ego="Kal-El",
                                first_appearance="Action Comics #1",
                                characters="Kal-El"   },
            new SuperheroItem { Id= 3,
                                Name="Flash",
                                publisher="DC Comics",
                                alter_ego="Jay Garrick",
                                first_appearance="Flash Comics #1",
                                characters="Jay Garrick, Barry Allen, Wally West, Bart Allen"
                              },
            new SuperheroItem { Id= 4,
                                Name="Green Lantern",
                                publisher="DC Comics", 
                                alter_ego="Alan Scott",
                                first_appearance="All-American Comics #16",
                                characters="Alan Scott, Hal Jordan, Guy Gardner, John Stewart, Kyle Raynor, Jade, Sinestro, Simon Baz"
                              },
            new SuperheroItem { Id= 5,
                                Name="Green Arrow", 
                                publisher="DC Comics", 
                                alter_ego="Oliver Queen",
                                first_appearance="More Fun Comics #73",
                                characters="Oliver Queen"
                              },
            new SuperheroItem { Id= 6,
                                Name="Wonder Woman", 
                                publisher="DC Comics", 
                                alter_ego="Princess Diana",
                                first_appearance="All Star Comics #8",
                                characters="Princess Diana"
                              },
            new SuperheroItem { Id= 7,
                                Name="Martian Manhunter", 
                                publisher="DC Comics", 
                                alter_ego="J'onn J'onzz",
                                first_appearance="Detective Comics #225",
                                characters="Martian Manhunter"
                              },
            new SuperheroItem { Id= 8,
                                Name="Robin/Nightwing", 
                                publisher="DC Comics", 
                                alter_ego="Dick Grayson",
                                first_appearance="Detective Comics #38",
                                characters="Dick Grayson"
                              },
            new SuperheroItem { Id= 9,
                                Name="Blue Beetle", 
                                publisher="DC Comics", 
                                alter_ego="Dan Garret",
                                first_appearance="Mystery Men Comics #1",
                                characters="Dan Garret, Ted Kord, Jaime Reyes"
                              },
            new SuperheroItem { Id= 10,
                                Name="Black Canary", 
                                publisher="DC Comics", 
                                alter_ego="Dinah Drake",
                                first_appearance="Flash Comics #86",
                                characters="Dinah Drake, Dinah Lance"
                              },
            new SuperheroItem { Id= 11,
                                Name="Spider Man", 
                                publisher="Marvel Comics", 
                                alter_ego="Peter Parker",
                                first_appearance="Amazing Fantasy #15",
                                characters="Peter Parker"
                              },
            new SuperheroItem { Id= 12,
                                Name="Captain America", 
                                publisher="Marvel Comics", 
                                alter_ego="Steve Rogers",
                                first_appearance="Captain America Comics #1",
                                characters="Steve Rogers"
                              },
            new SuperheroItem { Id= 13,
                                Name="Iron Man", 
                                publisher="Marvel Comics", 
                                alter_ego="Tony Stark",
                                first_appearance="Tales of Suspense #39",
                                characters="Tony Stark"
                              },
            new SuperheroItem { Id= 14,
                                Name="Thor", 
                                publisher="Marvel Comics", 
                                alter_ego="Thor Odinson",
                                first_appearance="Journey into Myster #83",
                                characters="Thor Odinson"
                              },
            new SuperheroItem { Id= 15,
                                Name="Hulk", 
                                publisher="Marvel Comics", 
                                alter_ego="Bruce Banner",
                                first_appearance="The Incredible Hulk #1",
                                characters="Bruce Banner"
                              },
            new SuperheroItem { Id= 16,
                                Name="Wolverine", 
                                publisher="Marvel Comics", 
                                alter_ego="James Howlett",
                                first_appearance="The Incredible Hulk #180",
                                characters="James Howlett"
                              },
            new SuperheroItem { Id= 17,
                                Name="Daredevil", 
                                publisher="Marvel Comics", 
                                alter_ego="Matthew Michael Murdock",
                                first_appearance="Daredevil #1",
                                characters="Matthew Michael Murdock"
                              },
            new SuperheroItem { Id= 18,
                                Name="Hawkeye", 
                                publisher="Marvel Comics", 
                                alter_ego="Clinton Francis Barton",
                                first_appearance="Tales of Suspense #57",
                                characters="Clinton Francis Barton"
                              },
            new SuperheroItem { Id= 19,
                                Name="Cyclops", 
                                publisher="Marvel Comics", 
                                alter_ego="Scott Summers",
                                first_appearance="X-Men #1",
                                characters="Scott Summers"
                              },
            new SuperheroItem { Id= 20,
                                Name="Silver Surfer", 
                                publisher="Marvel Comics", 
                                alter_ego="Norrin Radd",
                                first_appearance="The Fantastic Four #48",
                                characters="Norrin Radd"
                              }
        };

        [HttpGet]
        public ActionResult<List<SuperheroItem>> Get()
        {
            return Ok(Superheroes);
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult<SuperheroItem> Get(int Id)
        {
            var superheroItem = Superheroes.Find(x => x.Id == Id);
            return superheroItem == null ? NotFound() : Ok(superheroItem);
        }

        [HttpPost]
        public ActionResult Post(SuperheroItem superheroItem)
        {
            var existingSuperheroItem = Superheroes.Find(x => x.Id == superheroItem.Id);
            if (existingSuperheroItem != null)
            {
                return Conflict("Cannot create the Id because it already exists.");
            }
            else
            {
                Superheroes.Add(superheroItem);
                var resourceUrl = Request.Path.ToString() + '/' + superheroItem.Id;
                return Created(resourceUrl, superheroItem);
            }
        }

        [HttpPut]
        public ActionResult Put(SuperheroItem superheroItem)
        {
            var existingSuperheroItem = Superheroes.Find(x => x.Id == superheroItem.Id);
            if (existingSuperheroItem == null)
            {
                return BadRequest("Cannot update a nont existing term.");
            }
            else
            {
                existingSuperheroItem.Name = superheroItem.Name;
                return Ok();
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(int Id)
        {
            var superheroItem = Superheroes.Find(x => x.Id == Id);
            if (superheroItem == null)
            {
                return NotFound();
            }
            else
            {
                Superheroes.Remove(superheroItem);
                return NoContent();
            }
        }
    }
}