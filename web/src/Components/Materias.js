import React from 'react';
import { Button, Card, Modal, Table } from 'semantic-ui-react';
import './styles.css'

const materias = [
    {
        catedra: "Arquitectura de Software",
        profesor: "Frías, Pablo",
        añoCursado: "5",
        instancia: [
            {
                tipo: "Pacial",
                numero: "1",
                fecha: "Mon 06-04-2020 9:00",
                nota: "10",
                observacion: 'Parcial sobresaliente.'

            },
            {
                tipo: "Pacial",
                numero: "2",
                fecha: "Fri 12-06-2020 9:00",
                nota: "7",
                observacion: 'Buena interfaz.'

            },
            {
                tipo: "TPI",
                numero: "",
                fecha: "Mon 15-06-2020 9:00",
                nota: "10",
                observacion: "Excelente."

            },
        ],
    },
    {
        catedra: "Sistemas de Gestión",
        profesor: "Gualpa, Mariano Martín",
        añoCursado: "5",
        instancia: [
            {
                tipo: "Pacial",
                numero: "1",
                fecha: "Mon 06-04-2020 9:00",
                nota: "7",
                observacion: ""

            },
            {
                tipo: "Pacial",
                numero: "2",
                fecha: "Fri 12-06-2020 9:00",
                nota: "9",
                observacion: "Excelente."

            },
        ],
    },
    {
        catedra: "Inteligencia Artificial",
        profesor: "Destefanis, Eduardo Atilio",
        añoCursado: "5",
        instancia: [
            {
                tipo: "Pacial",
                numero: "1",
                fecha: "Mon 06-04-2020 12:00",
                nota: "8",
                observacion: ""

            },
            {
                tipo: "Pacial",
                numero: "2",
                fecha: "Wed 10-06-2020 16:00",
                nota: "6",
                observacion: "Bueno."

            },
        ],
    },
    {
        catedra: "Inteligencia de Negocios",
        profesor: "Magliano, Hernan Dario",
        añoCursado: "5",
        instancia: [
            {
                tipo: "Pacial",
                numero: "1",
                fecha: "Mon 06-04-2020 12:00",
                nota: "8",
                observacion: "Bueno."
            },
            {
                tipo: "TPI",
                numero: "",
                fecha: "Wed 10-06-2020 16:00",
                nota: "10",
                observacion: "Excelente."
            },
        ],
    }, 
    
]

function checkEmpty(value){
    if(value === ''){
        return '-'
    }
    return value
}
      
function modal(materia){
    return <Modal closeIcon trigger={<Button basic color='red' size='small'>Aula Virtual</Button>}>
        
        <Modal.Header>{materia.catedra}</Modal.Header>

        <Modal.Content scrolling>
            <Modal.Description>
                <b>
                    Profesor: {materia.profesor}
                </b>

                <Table color={'yellow'} key={'yellow'}>
                    <Table.Header>
                        <Table.Row>
                        <Table.HeaderCell>Fecha</Table.HeaderCell>
                        <Table.HeaderCell>Instancia</Table.HeaderCell>
                        <Table.HeaderCell>Numero</Table.HeaderCell>
                        <Table.HeaderCell>Nota</Table.HeaderCell>
                        <Table.HeaderCell>Observaciones</Table.HeaderCell>
                        </Table.Row>
                    </Table.Header>
            
                    <Table.Body>
                    {materia.instancia.map(instancia=> (
                        <Table.Row>
                            <Table.Cell>{instancia.fecha}</Table.Cell>
                            <Table.Cell>{instancia.tipo}</Table.Cell>
                            <Table.Cell>{checkEmpty(instancia.numero)}</Table.Cell>
                            <Table.Cell>{instancia.nota}</Table.Cell>
                            <Table.Cell>{checkEmpty(instancia.observacion)}</Table.Cell>
                        </Table.Row>
                        ))}
                    </Table.Body>
                </Table>
              
            </Modal.Description>
        </Modal.Content>
    </Modal>
}

export default function Materias(props) {
    return(
        <div className='utn'>            
            <Card.Group itemsPerRow={1}>
                {materias.map((materia, index)=>(
                    <Card key={index}>
                        <Card.Content>
                            <Card.Header>{materia.catedra}</Card.Header>
                            <Card.Meta>Año: {materia.añoCursado}</Card.Meta>
                            <Card.Description>{materia.profesor}</Card.Description>
                        </Card.Content>

                        <Card.Content extra>
                            {modal(materia)}
                        </Card.Content>
                            
                    </Card>
                ))}
            </Card.Group>    

        </div>

    )
}
