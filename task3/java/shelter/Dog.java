package task3.java.shelter;

public class Dog extends Animal implements Playable {

    public Dog(String name, int age) {
        super(name, age);
    }

    @Override
    public void interact() {
        System.out.println("Dog " + getName() + " happily wags its tail and barks!");
    }

    @Override
    public void play() {
        System.out.println(getName() + " is catching a frisbee!");
    }
}