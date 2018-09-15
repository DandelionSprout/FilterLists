import * as React from "react";
import { LinkButton } from "./LinkButton";

interface IProps {
    name: string;
    url: string;
    text?: string;
}

export const SubscribeButton = (props: IProps) => {
    let buttonClass: string | undefined;
    let titlePrefix: string;

    if (props.url.indexOf("https://") === -1) {
        buttonClass = "btn-danger";
        titlePrefix = "Not Secure - ";
    } else {
        buttonClass = undefined;
        titlePrefix = "";
    }

    const hrefTitle = `&amp;title=${encodeURIComponent(props.name)}`;
    const href = `abp:subscribe?location=${encodeURIComponent(props.url)}${hrefTitle}`;
    const title =
        `${titlePrefix}Subscribe to ${props.name
            } with a browser extension supporting the \"abp:\" protocol (e.g. uBlock Origin, Adblock Plus).`;

    return props.url
               ? <LinkButton href={href}
                             title={title}
                             buttonClass={buttonClass}
                             text={props.text || "Subscribe"}/>
               : null;
};