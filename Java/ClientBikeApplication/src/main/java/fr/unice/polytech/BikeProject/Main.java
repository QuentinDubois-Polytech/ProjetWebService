package fr.unice.polytech.BikeProject;

import fr.unice.polytech.BikeProject.generated.ApplicationService;
import fr.unice.polytech.BikeProject.generated.Direction;
import fr.unice.polytech.BikeProject.generated.IApplicationService;
import fr.unice.polytech.BikeProject.generated.Itinerary;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        /*
        Scanner sc = new Scanner(System.in);
        System.out.println("Rentrez l'adresse de votre point de départ : ");
        String origin = sc.nextLine();
        System.out.println("Rentrez l'adresse de votre point d'arrivée : ");
        String destination = sc.nextLine();
        */

        ApplicationService applicationService = new ApplicationService();
        IApplicationService service = applicationService.getBasicHttpBindingIApplicationService();
        Itinerary itinerary = service.getItinerary("Paris", "Lyon");

        System.out.println(toStringItinerary(itinerary));

        // System.out.println(service.getItinerary(new Position(), new Position()));
    }

    private static String toStringItinerary(Itinerary itinerary) {
        return "Distance: " + itinerary.getDistance() + " mètres" + System.lineSeparator() +
                "Duration: " + itinerary.getDuration() + " minutes" + System.lineSeparator();
    }
}
