import * as React from 'react';
import {Button, Card, Container,Form, FormControl, InputGroup, Row } from 'react-bootstrap';

interface ILogin{
    usuario: string,
    password: string,
}

const Login : React.FC = () => {
    const [login, setLogin] = React.useState<ILogin>({
        password: "",
        usuario: ""
    })

    const onInputChange = (e: React.ChangeEvent<any>) =>{
        const name = e.target.name;
        const value = e.target.value;
        setLogin({...login, [name]:value});
    }

    const isEnabledLogin = () => {
        return login.usuario !== "" && login.password !== ""
    }

    return (
        <Container>
            <Row className="d-flex justify-content-center">
                <Card className="mt-5">
                    <Card.Header>
                        <h3>Iniciar sesión</h3>
                    </Card.Header>
                    <Card.Body>
                        <Form>
                            <InputGroup className="mb-3">
                                <InputGroup.Prepend>
                                <InputGroup.Text id="basic-addon1">@</InputGroup.Text>                        
                                </InputGroup.Prepend>
                                <FormControl
                                    name="usuario"
                                    placeholder="USUARIO"
                                    aria-label="Usuario"
                                    aria-describedby="basic-addon1"
                                    tabIndex={0}
                                    autoFocus={true}
                                    onChange={onInputChange}
                                    className="text-uppercase"
                                />
                            </InputGroup>
                            <InputGroup className="mb-4">
                                <InputGroup.Prepend>
                                <InputGroup.Text id="basic-addon2">@</InputGroup.Text>                        
                                </InputGroup.Prepend>
                                <FormControl
                                    name="password"
                                    type="password"
                                    placeholder="CONTRASEÑA"
                                    aria-label="Contraseña"
                                    aria-describedby="basic-addon2"
                                    onChange={onInputChange}
                                />
                            </InputGroup>
                            <Button size="lg" block={true} disabled={!isEnabledLogin()} >Iniciar sesión</Button>
                        </Form>                        
                    </Card.Body>
                    <Card.Footer>
                        <Row className="d-flex justify-content-center links">
                            ¿No tienes una cuenta?&nbsp;<a href="#">Registrate</a>
                        </Row>
                        <Row className="d-flex justify-content-center links">
                            <a href="#">¿Olvidaste tu contraseña?</a>
                        </Row>
                    </Card.Footer>
                </Card>
            </Row>
        </Container>        
    )
}

export default Login;