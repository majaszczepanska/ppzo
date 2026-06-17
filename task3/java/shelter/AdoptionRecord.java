package task3.java.shelter;

import java.time.LocalDate;

public class AdoptionRecord {
    private Animal animal;
    private Adopter adopter;
    private LocalDate adoptionDate;

    public AdoptionRecord(Animal animal, Adopter adopter) {
        this.animal = animal;
        this.adopter = adopter;
        this.adoptionDate = LocalDate.now(); // Set todays date as the adoption date
    }

    public void process() {
        animal.adopt();
        adopter.addPet(animal);
        System.out.println("Adoption Record: " + adopter.getName() + " adopted " + animal.getName() + " on " + adoptionDate);
    }
}