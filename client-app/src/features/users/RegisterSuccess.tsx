import React from "react";
import { toast } from "react-toastify";
import { Button, Header, Icon, Segment } from "semantic-ui-react";
import agent from "../../app/api/agent";
import useQuery from "../../app/common/util/hooks";

function RegisterSuccess() {
  const email = useQuery().get("email") as string;

  function handleConfirmEmailResend() {
    agent.Account.resendEmailConfirmation(email)
      .then(() => {
        toast.success("Verficiation email resent - please check your email");
      })
      .catch((error) => console.log(error));
  }

  return (
    <Segment placeholder textAlign="center">
      <Header icon color="green">
        <Icon name="check" />
        Successfully registered!
      </Header>
      <p>Please check your email (including junk email) for the verification email.</p>
      {email && (
        <>
          <p>Didn't recieve the email? Click below to resend.</p>
          <Button primary onClick={handleConfirmEmailResend} content="Resend Email" size="huge" />
        </>
      )}
    </Segment>
  );
}

export default RegisterSuccess;
