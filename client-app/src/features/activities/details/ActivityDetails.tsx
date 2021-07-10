import React from "react";
import { Card, Image } from "semantic-ui-react";

export default function ActivityDetails() {
    return (
        <Card>
            <Image src='/images/avatar/large/matthew.png' wrapped ui={false} />
            <Card.Content>
                <Card.Header>matthew</Card.Header>
            </Card.Content>
        </Card>
    );
}