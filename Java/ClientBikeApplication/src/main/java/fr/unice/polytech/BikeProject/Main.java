package fr.unice.polytech.BikeProject;

import com.sun.xml.ws.fault.ServerSOAPFaultException;
import generated.*;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        String origin = "Avenue de Bretagne, 76100 Rouen";
        String destination = "24 Rue Grand Pont, 76000 Rouen";
        Map map = new Map();

        /*
        Scanner sc = new Scanner(System.in);
        System.out.println("Rentrez l'adresse de votre point de départ : ");
        String origin = sc.nextLine();
        System.out.println("Rentrez l'adresse de votre point d'arrivée : ");
        String destination = sc.nextLine();
        while (origin.equals(destination)){
            System.out.println("Vos adresse de départ et d'arrivée sont les mêmes!");
            System.out.println("Rentrez l'adresse de votre point de départ : ");
            origin = sc.nextLine();
            System.out.println("Rentrez l'adresse de votre point d'arrivée : ");
            destination = sc.nextLine();
        }*/

        ApplicationService applicationService = new ApplicationService();
        IApplicationService service = applicationService.getBasicHttpBindingIApplicationService();
        try{
            Itinerary itinerary = service.getItinerary(origin, destination);
            for (Direction d : itinerary.getDirections().getValue().getDirection()) {
                System.out.println("Moyen de transport : " + d.getProfile().getValue());
                for (Step s : d.getSegment().getValue().getSteps().getValue().getStep()){
                    System.out.println("In " + s.getDistance().intValue() + " meters " + s.getInstruction().getValue());
                }
            }
            map.setGeoPosition(itinerary);
            map.draw();
            System.out.println("You have arrived!");}
        catch (ServerSOAPFaultException exception) {System.out.println(exception.getMessage());}
    }
}
