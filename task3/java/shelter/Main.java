package task3.java.shelter;

public class Main {
    public static void main(String[] args) {
        // Creating a shelter instance
        Shelter myShelter = new Shelter();

        // Creating objects (Animals and Adopter)
        Dog dog1 = new Dog("dog1", 3);
        Dog dog2 = new Dog("dog2", 1);
        Cat cat1 = new Cat("cat1", 2);
        
        Adopter adopter1 = new Adopter("Alice");

        // Adding to the shelter
        myShelter.addAnimal(dog1);
        myShelter.addAnimal(dog2);
        myShelter.addAnimal(cat1);

        myShelter.showAnimals();

        // Adoption process - first version (direct method call)
        //myShelter.processAdoption(dog1, adopter1);

        //Demonstrating polymorphism and interface usage
        System.out.println("--- Playtime ---");
        dog1.play();
        cat1.play();
        System.out.println("----------------\n");

        // Using AdoptionRecord to process adoption
        if (myShelter.hasAnimal(dog1)) {
            AdoptionRecord record = new AdoptionRecord(dog1, adopter1);
            record.process();
            myShelter.removeAnimal(dog1); // Removing the adopted animal from the shelter
        }

        // Checking the state after adoption
        myShelter.showAnimals();
    }
}