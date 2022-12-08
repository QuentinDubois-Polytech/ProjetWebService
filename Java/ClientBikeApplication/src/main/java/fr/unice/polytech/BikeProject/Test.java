package fr.unice.polytech.BikeProject;

import com.sun.xml.ws.fault.ServerSOAPFaultException;
import generated.*;

import java.util.Scanner;

public class Test {
    public static void main(String[] args) {

        String origin = "137 Quai de Rouen Quevilly, 76100 Rouen";
        String destination = "37 Bd toto, Nice";


        ApplicationService applicationService = new ApplicationService();
        IApplicationService service = applicationService.getBasicHttpBindingIApplicationService();
        try{
            Itinerary itinerary = service.getItinerary(origin, destination);
            System.out.println(itinerary.isIsException());
            System.out.println(itinerary.getException().getValue());
            for (Direction d : itinerary.getDirections().getValue().getDirection()) {
                System.out.println(d.getProfile().getValue());
                for (Step s : d.getSegment().getValue().getSteps().getValue().getStep()){
                    System.out.println("In " + s.getDistance().intValue() + " meters " + s.getInstruction().getValue());
                }
            }
            System.out.println("You have arrived!");}
        catch (ServerSOAPFaultException exception) {System.out.println(exception.getMessage());}
    }
}
