package task3.java.shelter;

import java.util.UUID;

public abstract class Animal {
    private String id;
    private String name;
    private int age;
    private boolean isAdopted;

    public Animal(String name, int age) {
        this.id = UUID.randomUUID().toString();
        this.name = name;
        this.age = age;
        this.isAdopted = false;
    }

    public String getId() {
        return id; 
    }
    public String getName() {
        return name; 
    }
    public int getAge() { 
        return age; 
}
    public boolean isAdopted() { 
        return isAdopted; 
    }

    public void adopt() {
        this.isAdopted = true;
    }

    // Abstract method (polymorphism and abstraction)
    public abstract void interact();
}