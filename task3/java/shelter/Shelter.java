package task3.java.shelter;

import java.util.ArrayList;
import java.util.List;

public class Shelter {
    private List<Animal> availableAnimals; // Relationship: Collection (Aggregation)

    public Shelter() {
        this.availableAnimals = new ArrayList<>();
    }

    public void addAnimal(Animal animal) {
        availableAnimals.add(animal);
        System.out.println("Added to shelter: " + animal.getName());
    }
    
    public void removeAnimal(Animal animal) {
        availableAnimals.remove(animal);
    }
    public boolean hasAnimal(Animal animal) {
        return availableAnimals.contains(animal);
    }

    public void showAnimals() {
        System.out.println("\n--- Animals in the shelter ---");
        if (availableAnimals.isEmpty()) {
            System.out.println("The shelter is empty.");
            return;
        }
        for (Animal animal : availableAnimals) {
            // Polymorphic method call
            animal.interact(); 
        }
        System.out.println("------------------------------\n");
    }

    // Relationship: Method parameters
    public void processAdoption(Animal animal, Adopter adopter) {
        if (availableAnimals.contains(animal)) {
            animal.adopt(); // State change (Encapsulation)
            adopter.addPet(animal);
            availableAnimals.remove(animal);
            System.out.println("Success: Animal " + animal.getName() + " found a new home!");
        } else {
            System.out.println("Error: This animal is not in the shelter.");
        }
    }
}