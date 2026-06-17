package task3.java.shelter;

public class Cat extends Animal implements Playable {

    public Cat(String name, int age) {
        super(name, age);
    }

    @Override
    public void interact() {
        System.out.println("Cat " + getName() + " rubs against your legs and purrs loudly.");
    }

    @Override
    public void play() {
        System.out.println(getName() + " is chasing a laser pointer!");
    }
}