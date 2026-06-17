package task3.java;

public class Cat extends Animal {

    public Cat(String name, int age) {
        super(name, age);
    }

    @Override
    public void interact() {
        System.out.println("Cat " + getName() + " rubs against your legs and purrs loudly.");
    }
}