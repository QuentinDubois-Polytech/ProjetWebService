package fr.unice.polytech.BikeProject;

import com.sun.xml.ws.fault.ServerSOAPFaultException;
import generated.*;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        boolean keepAsking = true;
        String origin;
        String destination;
        //String origin = "Avenue de Bretagne, 76000 Rouen";
        //String destination = "24 Rue Grand Pont, 76000 Rouen";
        Itinerary itinerary = new Itinerary();

        while(keepAsking){
            Scanner sc = new Scanner(System.in);
            System.out.println("Rentrez l'adresse de votre point de départ : ");
            origin = sc.nextLine();
            System.out.println("Rentrez l'adresse de votre point d'arrivée : ");
            destination = sc.nextLine();

            if(!origin.equals(destination)) keepAsking= false;
            else continue;

            try {
                ApplicationService applicationService = new ApplicationService();
                IApplicationService service = applicationService.getBasicHttpBindingIApplicationService();
                itinerary = service.getItinerary(origin, destination);
            } catch (ServerSOAPFaultException serverSOAPFaultException){
                if(itinerary.isIsException().booleanValue()) {
                    System.out.println(itinerary.getException().getValue());{
                    if (itinerary.getException().getValue().contains("No station was found in the contract name: "))
                        keepAsking = false;
                    }
                }
            }
        }

        for (Direction d : itinerary.getDirections().getValue().getDirection()) {
            System.out.println("Moyen de transport : " + d.getProfile().getValue());
            for (Step s : d.getSegment().getValue().getSteps().getValue().getStep()){
                System.out.println("In " + s.getDistance().intValue() + " meters " + s.getInstruction().getValue());
            }
        }

        Map map = new Map();
        map.setGeoPosition(itinerary);
        map.draw();
        System.out.println("You have arrived!");
    }
}
