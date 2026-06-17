package task3.java.shelter;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class Adopter {
    private String id;
    private String name;
    private List<Animal> adoptedPets; // Relationship: Collection (Composition)

    public Adopter(String name) {
        this.id = UUID.randomUUID().toString();
        this.name = name;
        this.adoptedPets = new ArrayList<>();
    }

    public String getName() { return name; }

    public void addPet(Animal pet) {
        adoptedPets.add(pet);
        System.out.println(this.name + " officially adopts a pet named: " + pet.getName());
    }
}
