package fr.unice.polytech.BikeProject;

import generated.*;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        boolean keepAsking = true;
        String origin = null;
        String destination = null;

        do {
            Scanner sc = new Scanner(System.in);
            while (origin == null || origin.trim().isEmpty()) {
                System.out.println("Enter the address of your starting point: ");
                origin = sc.nextLine();

                if (origin.trim().isEmpty()) {
                    System.out.println("You need to enter an address");
                }
            }

            while (destination == null || destination.trim().isEmpty()) {
                System.out.println("Enter the address of your arrival point: ");
                destination = sc.nextLine();

                if (destination.trim().isEmpty()) {
                    System.out.println("You need to enter an address");
                }
            }

            origin = origin.toLowerCase().trim();
            destination = destination.toLowerCase().trim();

            if(!origin.equals(destination)) {
                keepAsking= false;
                System.out.println();
            } else {
                System.out.println("The starting and ending points must be different");
                origin = null;
                destination = null;
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