
package generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour Itinerary complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="Itinerary"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="coordinates" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfArrayOffloat" minOccurs="0"/&gt;
 *         &lt;element name="directions" type="{http://schemas.datacontract.org/2004/07/ApplicationServer}ArrayOfDirection" minOccurs="0"/&gt;
 *         &lt;element name="distance" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="duration" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="exception" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *         &lt;element name="isException" type="{http://www.w3.org/2001/XMLSchema}boolean" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Itinerary", propOrder = {
    "coordinates",
    "directions",
    "distance",
    "duration",
    "exception",
    "isException"
})
public class Itinerary {

    @XmlElementRef(name = "coordinates", namespace = "http://schemas.datacontract.org/2004/07/ApplicationServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArrayOffloat> coordinates;
    @XmlElementRef(name = "directions", namespace = "http://schemas.datacontract.org/2004/07/ApplicationServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfDirection> directions;
    protected Double distance;
    protected Double duration;
    @XmlElementRef(name = "exception", namespace = "http://schemas.datacontract.org/2004/07/ApplicationServer", type = JAXBElement.class, required = false)
    protected JAXBElement<String> exception;
    protected Boolean isException;

    /**
     * Obtient la valeur de la propriété coordinates.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOffloat }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArrayOffloat> getCoordinates() {
        return coordinates;
    }

    /**
     * Définit la valeur de la propriété coordinates.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOffloat }{@code >}
     *     
     */
    public void setCoordinates(JAXBElement<ArrayOfArrayOffloat> value) {
        this.coordinates = value;
    }

    /**
     * Obtient la valeur de la propriété directions.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfDirection }{@code >}
     *     
     */
    public JAXBElement<ArrayOfDirection> getDirections() {
        return directions;
    }

    /**
     * Définit la valeur de la propriété directions.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfDirection }{@code >}
     *     
     */
    public void setDirections(JAXBElement<ArrayOfDirection> value) {
        this.directions = value;
    }

    /**
     * Obtient la valeur de la propriété distance.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getDistance() {
        return distance;
    }

    /**
     * Définit la valeur de la propriété distance.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setDistance(Double value) {
        this.distance = value;
    }

    /**
     * Obtient la valeur de la propriété duration.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getDuration() {
        return duration;
    }

    /**
     * Définit la valeur de la propriété duration.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setDuration(Double value) {
        this.duration = value;
    }

    /**
     * Obtient la valeur de la propriété exception.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getException() {
        return exception;
    }

    /**
     * Définit la valeur de la propriété exception.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setException(JAXBElement<String> value) {
        this.exception = value;
    }

    /**
     * Obtient la valeur de la propriété isException.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isIsException() {
        return isException;
    }

    /**
     * Définit la valeur de la propriété isException.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setIsException(Boolean value) {
        this.isException = value;
    }

}
