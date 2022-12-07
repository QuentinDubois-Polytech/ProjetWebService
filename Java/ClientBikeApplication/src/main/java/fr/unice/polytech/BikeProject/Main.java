package fr.unice.polytech.BikeProject;

import generated.*;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        boolean keepAsking = true;
        String origin;
        String destination;

        do {
            Scanner sc = new Scanner(System.in);
            System.out.println("Rentrez l'adresse de votre point de départ : ");
            origin = sc.nextLine();
            System.out.println("Rentrez l'adresse de votre point d'arrivée : ");
            destination = sc.nextLine();

            origin = origin.toLowerCase().trim();
            destination = destination.toLowerCase().trim();

            if(!origin.equals(destination)) {
                keepAsking= false;
                System.out.println();
            } else {
                System.out.println("Le point de départ et d'arrivée doivent être différents");
            }
        } while(keepAsking);

        ApplicationService applicationService = new ApplicationService();
        IApplicationService service = applicationService.getBasicHttpBindingIApplicationService();
        Itinerary itinerary = service.getItinerary(origin, destination);

        if (itinerary.isIsException()) {
            System.out.println(itinerary.getException().getValue());
        }

        // Display the itinerary in the terminal
        if (itinerary.getDirections().getValue() != null && itinerary.getDirections().getValue().getDirection().size() != 0) {
            System.out.println("You cannot use a bike for this itinerary");
            System.out.println("We still propose you a walking itinerary");
            System.out.println();
            System.out.println("Total duration : " + Math.ceil(itinerary.getDuration()) + " minutes");
            System.out.println("Total distance : " + Math.ceil(itinerary.getDistance()) + " meters");
            for (Direction d : itinerary.getDirections().getValue().getDirection()) {
                System.out.println();
                System.out.println("Means of transport : " + d.getProfile().getValue());
                System.out.println("-----------------------------------------------------------------------------------------");
                for (Step s : d.getSegment().getValue().getSteps().getValue().getStep()) {
                    System.out.println("In " + s.getDistance().intValue() + " meters " + s.getInstruction().getValue());
                }
            }

            System.out.println("You have arrived!");

            // Display the itinerary on a map
            Map map = new Map();
            map.setGeoPosition(itinerary);
            map.draw();
        }
    }
}