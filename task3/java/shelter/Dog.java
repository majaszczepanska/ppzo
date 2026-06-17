package task3.java;

public class Dog extends Animal {

    public Dog(String name, int age) {
        super(name, age);
    }

    @Override
    public void interact() {
        System.out.println("Dog " + getName() + " happily wags its tail and barks!");
    }
}