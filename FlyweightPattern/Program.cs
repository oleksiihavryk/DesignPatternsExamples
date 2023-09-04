using FlyweightPattern;

//Flyweight pattern - pattern for optimize usage of data in classes
//by referencing to class that encapsulate a similar and most repeating data.

var map = new Map();

//In this example ParticleInfo is a flyweight in Particle class.
var blueParticle = new ParticleInfo(ConsoleColor.Blue, "-");
var yellowParticle = new ParticleInfo(ConsoleColor.Yellow, "-");

var particles = new Particle[,]
{
    {
        new(map, blueParticle, new Coordinate(0, 0)),
        new(map, blueParticle, new Coordinate(1, 0)), 
        new(map, blueParticle, new Coordinate(2, 0)),
        new(map, blueParticle, new Coordinate(3, 0)),
        new(map, blueParticle, new Coordinate(4, 0)),
        new(map, blueParticle, new Coordinate(5, 0))
    },
    {
        new(map, blueParticle, new Coordinate(0, 1)),
        new(map, blueParticle, new Coordinate(1, 1)),
        new(map, blueParticle, new Coordinate(2, 1)),
        new(map, blueParticle, new Coordinate(3, 1)),
        new(map, blueParticle, new Coordinate(4, 1)),
        new(map, blueParticle, new Coordinate(5, 1))
    },
    {
        new(map, yellowParticle, new Coordinate(0, 2)),
        new(map, yellowParticle, new Coordinate(1, 2)),
        new(map, yellowParticle, new Coordinate(2, 2)),
        new(map, yellowParticle, new Coordinate(3, 2)),
        new(map, yellowParticle, new Coordinate(4, 2)),
        new(map, yellowParticle, new Coordinate(5, 2))
    },
    {
        new(map, yellowParticle, new Coordinate(0, 3)),
        new(map, yellowParticle, new Coordinate(1, 3)),
        new(map, yellowParticle, new Coordinate(2, 3)),
        new(map, yellowParticle, new Coordinate(3, 3)),
        new(map, yellowParticle, new Coordinate(4, 3)),
        new(map, yellowParticle, new Coordinate(5, 3))
    },
};

map.Particles = particles;

var mapViewer = new MapViewer(map);

mapViewer.Show();
