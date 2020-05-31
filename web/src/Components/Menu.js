import React from 'react'
import { Container, Header, Image, List, Menu, Segment, Grid } from 'semantic-ui-react'
import utn from '../UTN.png'
import Materias from './Materias'
import './styles.css'

const FixedMenuLayout = () => (
  <div>
    <Menu fixed='top' inverted>
        <Container>
            <Menu.Item as='a' header>
            <Image size='mini' src={utn} style={{ marginRight: '1.5em' }} />
            UTN
            </Menu.Item>
            <Menu.Item as='a' active={true}>Autogestión</Menu.Item>
            <Menu.Item as='a'>UV</Menu.Item>
            <Menu.Item as='a'>Noticias</Menu.Item>
            <Menu.Item as='a' position='right'>Cerrar Sesión</Menu.Item>
        </Container>
    </Menu>


    <Container text style={{ marginTop: '7em' }}>
        <Header as='h1' style={{ textAlign: 'center' }}>Mi Aula Virtual</Header>
        <div style={{ textAlign: 'center', color: 'rgb(27, 28, 29)', margin: '0px' }}>Ciclo lectivo 2020</div>

        <Materias/>
        
        <Grid divided columns={3} style={{ marginTop: '4em' }}>
          <Grid.Column>
            <Header as='h4' content='Cursado' />
            <List link>
              <List.Item as='a'>Mis Horarios</List.Item>
              <List.Item as='a'>Histórico de Cursado</List.Item>
              <List.Item as='a'>Histórico de Regulares</List.Item>
              <List.Item as='a'>Histórico de libres</List.Item>
            </List>
          </Grid.Column>
          <Grid.Column>
            <Header as='h4' content='Examenes' />
            <List link>
              <List.Item as='a'>Estado Académico</List.Item>
              <List.Item as='a'>Fechas de Exámenes</List.Item>
              <List.Item as='a'>Aprobados</List.Item>
              <List.Item as='a'>Mis incripciones</List.Item>
            </List>
          </Grid.Column>
          <Grid.Column>
            <Header as='h4' content='Materias' />
            <List link>
              <List.Item as='a'>Materias del Plan</List.Item>
              <List.Item as='a'>Correlatividad para Cursar</List.Item>
              <List.Item as='a'>Correlatividad para Rendir</List.Item>
              <List.Item as='a'>Equivalencias</List.Item>
            </List>
          </Grid.Column>
        </Grid>

    </Container>


    <Segment inverted vertical style={{ margin: '5em 0em 0em', padding: '3em 0em' }} className='footer'>
        <Container textAlign='center'>
            <Header>Universidad Tecnológica Nacional</Header>
            <List horizontal inverted divided link size='small'>
            <List.Item>
                Facultad Regional Córdoba
            </List.Item>
            </List>
        </Container>
    </Segment>
  </div>
)

export default FixedMenuLayout