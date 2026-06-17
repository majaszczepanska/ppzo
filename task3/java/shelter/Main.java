package task3.java;

public class Main {
    public static void main(String[] args) {
        // Creating a shelter instance
        Shelter myShelter = new Shelter();

        // Creating objects (Animals and Adopter)
        Dog dog1 = new Dog("Burek", 3);
        Dog dog2 = new Dog("Reksio", 1);
        Cat cat1 = new Cat("Mruczek", 2);
        
        Adopter adopter1 = new Adopter("Jan Kowalski");

        // Adding to the shelter
        myShelter.addAnimal(dog1);
        myShelter.addAnimal(dog2);
        myShelter.addAnimal(cat1);

        // Demonstrating polymorphism
        myShelter.showAnimals();

        // Adoption process
        myShelter.processAdoption(dog1, adopter1);

        // Checking the state after adoption
        myShelter.showAnimals();
    }
}